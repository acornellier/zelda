using Animancer;
using Animancer.FSM;
using CleverCrow.Fluid.BTs.Tasks;
using UnityEngine;

public abstract class CharacterState : StateBehaviour
{
    [SerializeField]
    private string _name;
    public string Name
    {
        get => string.IsNullOrEmpty(_name) ? name : _name;
    }

    public Character character;
    public StateMachine<CharacterState> OwnerStateMachine => character.stateMachine;

    [HideInInspector]
    public float timeSinceEnabled;

    protected virtual void OnEnable()
    {
        timeSinceEnabled = 0;
    }

    protected virtual void Update()
    {
        timeSinceEnabled += Time.deltaTime;
    }

    public bool IsCurrentState() => OwnerStateMachine.CurrentState == this;

    public bool TryEnterState() => OwnerStateMachine.TrySetState(this);

    public TaskStatus TryEnterAction() => TryEnterState() ? TaskStatus.Success : TaskStatus.Failure;

    public void ForceState() => OwnerStateMachine.ForceSetState(this);

    public TaskStatus ForceStateAction()
    {
        ForceState();
        return TaskStatus.Success;
    }

#if UNITY_EDITOR
    protected void Reset()
    {
        character = gameObject.GetComponentInParentOrChildren<Character>();
    }
#endif
}
