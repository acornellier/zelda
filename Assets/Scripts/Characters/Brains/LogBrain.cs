using Animancer;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

public class LogBrain : CharacterBrain
{
    public LoopState sleeping;
    public ClipState waking;
    public LocomotionState moving;

    public float wakeRadius;
    public float chaseRadius;
    public Transform homePosition;

    public BehaviorTree tree;

    Transform target;

    void OnEnable()
    {
        CreateTree();
        sleeping.TryEnterState();
    }

    void CreateTree()
    {
        tree = new BehaviorTreeBuilder(gameObject)
            .Selector()
            .Sequence("Waking up")
                .Condition("Sleeping", () => sleeping.IsCurrentState())
                .Do("Try wake up", TryWakeUp)
            .End()
            .Sequence("Chasing")
                .Condition("Within chase radius", () => DistanceTo(target) < chaseRadius)
                .Do("Go home", () => MoveTo(target))
            .End()
            .Sequence("Resetting")
                .Condition(
                    "Away from home",
                    () => DistanceTo(target) > chaseRadius && DistanceTo(homePosition) > 0.01
                )
                .Do("Chase target", () => MoveTo(homePosition))
            .End()
            .Sequence("Falling asleep")
                .Condition(
                    "Idle for long enough",
                    () => character.idle.IsCurrentState() && character.idle.timeSinceEnabled > 2
                )
                .Do("Fall asleep", () => sleeping.TryEnterAction())
            .End()
            .Do(() => character.idle.TryEnterAction())
            .Build();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        tree.Tick();
    }

    TaskStatus TryWakeUp() =>
        DistanceTo(target) < wakeRadius ? waking.ForceStateAction() : TaskStatus.Continue;

    float DistanceTo(Transform destination) =>
        Vector2.Distance(character.transform.position, destination.transform.position);

    TaskStatus MoveTo(Transform destination)
    {
        character.MovementDirection = destination.transform.position - character.transform.position;
        return moving.TryEnterAction();
    }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.GetComponentInParentOrChildren(ref sleeping);
        gameObject.GetComponentInParentOrChildren(ref moving);
    }
#endif
}
