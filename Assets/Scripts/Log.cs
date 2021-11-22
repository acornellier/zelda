using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    Animator animator;
    Rigidbody2D body;

    void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        // CheckDistance();
    }

    void CheckDistance()
    {
        var targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= chaseRadius && targetDistance > attackRadius)
        {
            body.MovePosition(
                Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime)
            );
        }
    }
}
