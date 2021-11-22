using UnityEngine;

public enum LogState
{
    sleep,
    gettingUp,
    idle,
    walk
}

public class LogMovement : MonoBehaviour
{
    public float speed;

    Animator animator;
    Rigidbody2D body;
    Vector3 change;
    LogState currentState = LogState.sleep;
    float? lastDirectionChangeTimestamp = null;

    void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // SceneLinkedSMB<LogMovement>.Initialize(animator, this);
    }

    void Update()
    {
        var randomValue = Random.value;
        if (currentState == LogState.sleep)
        {
            if (randomValue < 0.10)
            {
                currentState = LogState.gettingUp;
                animator.SetTrigger("wakeUp");
            }
        }
        else if (currentState == LogState.idle)
        {
            if (randomValue < 0.01)
            {
                currentState = LogState.sleep;
                animator.SetTrigger("goToSleep");
            }
            else if (randomValue < 0.10)
            {
                currentState = LogState.walk;
                animator.SetBool("walking", true);
            }
        }
        else if (currentState == LogState.walk)
        {
            if (randomValue < 0.01)
            {
                currentState = LogState.idle;
                animator.SetBool("walking", false);
            }
            else
            {
                if (
                    lastDirectionChangeTimestamp == null
                    || Time.time > lastDirectionChangeTimestamp + 5
                )
                {
                    change = Vector3.zero;
                    lastDirectionChangeTimestamp = Time.time;
                    do
                    {
                        change = new Vector2(
                            Mathf.Round(Random.Range(-1f, 1f)),
                            Mathf.Round(Random.Range(-1f, 1f))
                        );
                    } while (change == Vector3.zero);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (currentState == LogState.walk && change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
        }
    }

    void MoveCharacter()
    {
        body.MovePosition(transform.position + speed * Time.deltaTime * change.normalized);
    }

    public void SetStateWalking()
    {
        currentState = LogState.walk;
    }
}
