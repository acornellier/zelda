using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Animator animator;
    Rigidbody2D body;
    Vector3 change;
    PlayerState currentState = PlayerState.walk;

    void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SceneLinkedSMB<PlayerMovement>.Initialize(animator, this);
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            animator.SetTrigger("attacking");
            currentState = PlayerState.attack;
        }
    }

    void FixedUpdate()
    {
        if (currentState == PlayerState.walk)
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
    }

    void MoveCharacter()
    {
        body.MovePosition(transform.position + speed * Time.deltaTime * change.normalized);
    }

    public void SetStateWalking()
    {
        currentState = PlayerState.walk;
    }
}
