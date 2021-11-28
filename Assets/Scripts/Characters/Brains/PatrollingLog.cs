using Animancer;
using CleverCrow.Fluid.BTs.Trees;

public class PatrollingLog : LogBrain
{
    public LocomotionState patrolling;

    override protected void CreateTree()
    {
        tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
            .Splice(BuildChaseNode())
            .Do("Patrol", patrolling.TryEnterAction)
            .Build();
    }

#if UNITY_EDITOR
    override protected void OnValidate()
    {
        base.OnValidate();
        gameObject.GetComponentInParentOrChildren(ref moving);
    }
#endif
}
