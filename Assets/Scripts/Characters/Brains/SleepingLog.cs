using Animancer;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

public class SleepingLog : LogBrain
{
    public LoopState sleeping;
    public ClipState waking;

    public float wakeRadius;
    public Transform homePosition;

    override protected void OnEnable()
    {
        base.OnEnable();
        sleeping.TryEnterState();
    }

    override protected void CreateTree()
    {
        tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
            .Sequence("Waking up")
                .Condition("Sleeping", () => sleeping.IsCurrentState())
                .Do("Try wake up", TryWakeUp)
            .End()
            .Splice(BuildChaseNode())
            .Sequence("Resetting")
                .Condition(
                    "Away from home",
                    () => DistanceTo(target) > chaseRadius && DistanceTo(homePosition) > 0.01
                )
                .Do("Return home", () => MoveTo(homePosition))
            .End()
            .Sequence("Falling asleep")
                .Condition(
                    "Idle for long enough",
                    () => character.idle.IsCurrentState() && character.idle.timeSinceEnabled > 2
                )
                .Do("Fall asleep", sleeping.TryEnterAction)
            .End()
            .Do(character.idle.TryEnterAction)
            .Build();
    }

    TaskStatus TryWakeUp() =>
        DistanceTo(target) < wakeRadius ? waking.ForceStateAction() : TaskStatus.Continue;

#if UNITY_EDITOR
    override protected void OnValidate()
    {
        base.OnValidate();
        gameObject.GetComponentInParentOrChildren(ref sleeping);
        gameObject.GetComponentInParentOrChildren(ref moving);
    }
#endif
}
