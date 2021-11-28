using Animancer;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

public abstract class LogBrain : CharacterBrain
{
    public LocomotionState moving;
    public float chaseRadius;
    public BehaviorTree tree;

    protected Transform target;

    virtual protected void OnEnable()
    {
        CreateTree();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    virtual protected void Update() => tree.Tick();

    abstract protected void CreateTree();

    protected BehaviorTree BuildChaseNode()
    {
        return new BehaviorTreeBuilder(gameObject)
            .Sequence("Chasing")
                .Condition("Within chase radius", () => DistanceTo(target) < chaseRadius)
                .Do("Chase target", () => MoveTo(target))
            .End()
            .Build();
    }

    protected float DistanceTo(Transform destination)
    {
        return Vector2.Distance(character.transform.position, destination.transform.position);
    }

    protected TaskStatus MoveTo(Transform destination)
    {
        character.MovementDirection = destination.transform.position - character.transform.position;
        return moving.TryEnterAction();
    }

#if UNITY_EDITOR
    override protected void OnValidate()
    {
        base.OnValidate();
        gameObject.GetComponentInParentOrChildren(ref moving);
    }
#endif
}
