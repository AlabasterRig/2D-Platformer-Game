using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator; 
    public BoxCollider2D boxCollider;
    public Vector2 BoxCollisionInitialOffset;
    public Vector2 BoxCollisionInitialSize;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private Rigidbody2D rb;

    public ScoreController scoreController;
    public LevelController levelController;
    private bool IsGrounded;
    public float Speed = 8;
    public float Jump;
    public float GroundCheckRadius = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BoxCollisionInitialOffset = boxCollider.offset;
        BoxCollisionInitialSize = boxCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        float Horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(Horizontal);
        PlayerMovementAnimation(Horizontal);
        PlayerCrouchAnimation();
        PlayerJumpAnimation();
    }

    private void MoveCharacter(float Horizontal)
    {
        // Move Character Horizontally
        if (IsGrounded)
        {
            Vector3 Position = transform.position;
            Position.x += Horizontal * Speed * Time.deltaTime;
            transform.position = Position;
        }

        // Move Character Vertically
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.AddForce(new Vector2(0f, Jump), ForceMode2D.Impulse);
        }
    }

    private void PlayerMovementAnimation(float Horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));
        Vector3 scale = transform.localScale;
        if (Horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (Horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void PlayerCrouchAnimation()
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if(Crouch)
        {
            float NewOffsetY = 0.60345f;
            float NewOffsetX = 0.027414f;

            float NewSizeY = 0.67524f;
            float NewSizeX = 1.3595f;

            boxCollider.offset = new Vector2(NewOffsetX, NewOffsetY);
            boxCollider.size = new Vector2(NewSizeX, NewSizeY);
        }
        else
        {
            boxCollider.offset = BoxCollisionInitialOffset;
            boxCollider.size = BoxCollisionInitialSize;
        }
        animator.SetBool("Crouch", Crouch);
    }

    private void PlayerJumpAnimation()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        if (!animator.GetBool("IsDead"))
        {
            Debug.Log("Player is dead");
            animator.SetTrigger("Death");
            animator.SetBool("IsDead", true);
        }
        RestartLevel();
    }

    public void RestartLevel()
    {
        levelController.ReloadLevel();
    }
}
