using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Animator animator;
    Rigidbody2D body;
    Vector3 change;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void MoveCharacter()
    {
        body.MovePosition(transform.position + speed * Time.deltaTime * change.normalized);
    }
}
