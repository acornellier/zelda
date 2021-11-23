using Animancer;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

public class LogBrain : CharacterBrain
{
    public LoopState sleeping;
    public ClipState waking;
    public LocomotionState chasing;

    public float wakeRadius;
    public float chaseRadius;
    public Transform homePosition;
    public Transform target;

    public BehaviorTree tree;

    void Awake()
    {
        OnEnable();
    }

    void OnEnable()
    {
        sleeping.TryEnterState();
        tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
            .Sequence("Waking up")
                .Condition("Sleeping", () => sleeping.IsCurrentState())
                .Condition("Within wake radius", () => DistanceToTarget() < wakeRadius)
                .Do("Wake up", () => waking.ForceStateAction())
            .End()
            .Sequence("Chasing")
                .Condition("Awake", () => !sleeping.IsCurrentState())
                .Condition("Within chase radius", () => DistanceToTarget() < chaseRadius)
                .Do("Chase target", ChaseTarget)
            .End()
            .Sequence("Falling asleep")
                .Condition("Idle", () => character.idle.IsCurrentState())
                .RandomChance(1, 1000)
                .Do("Fall asleep", () => sleeping.TryEnterAction())
            .End()
            .Do(() => character.idle.TryEnterAction())
            .Build();
    }

    void Update()
    {
        tree.Tick();
    }

    float DistanceToTarget() =>
        Vector2.Distance(character.transform.position, target.transform.position);

    TaskStatus ChaseTarget()
    {
        character.MovementDirection = target.transform.position - character.transform.position;
        return chasing.TryEnterAction();
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.GetComponentInParentOrChildren(ref sleeping);
        gameObject.GetComponentInParentOrChildren(ref chasing);
    }
#endif
}
