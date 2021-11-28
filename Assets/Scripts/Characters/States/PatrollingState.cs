using UnityEngine;

public sealed class PatrollingState : LocomotionState
{
    public Transform[] path;

    int curGoalIndex;

    // protected override void OnEnable()
    // {
    // base.OnEnable();
    // }

    protected override void Update()
    {
        base.Update();

        var curGoal = path[curGoalIndex];

        if (Vector2.Distance(transform.position, curGoal.position) < walkSpeed * Time.deltaTime)
        {
            curGoalIndex = (curGoalIndex + 1) % path.Length;
        }
        else
        {
            character.MovementDirection = curGoal.position - transform.position;
        }
    }
}
