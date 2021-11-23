using UnityEngine;

public class ChaseState : CharacterState
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    void OnEnable()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        var targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= chaseRadius && targetDistance > attackRadius)
        {
            // body.MovePosition(
            // Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime)
            // );
        }
    }
}
