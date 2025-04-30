using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerCrouch();
        PlayerJump();
    }

    private void PlayerMovement()
    {
        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(Speed));
        Vector3 scale = transform.localScale;
        if (Speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (Speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void PlayerCrouch()
    {
        bool Crouch = Input.GetKey(KeyCode.LeftControl);
        if(Crouch)
        {
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void PlayerJump()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        if (Vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else if (Vertical <= 0)
        {
            animator.SetBool("Jump", false);
        }
    }
}
