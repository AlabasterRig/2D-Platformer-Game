using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public Transform PointA;
    public Transform PointB;
    public float Speed = 2f;

    private Rigidbody2D rb;
    private Vector3 target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = PointB.position;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        PlayAnimation();
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        rb.MovePosition(newPosition);

        // Switch target when close
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = (target == PointA.position) ? PointB.position : PointA.position;
            Flip();
        }
    }

    private void PlayAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(Speed));
        if(Speed > 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(1);
        }
    } 
}
