using Animancer;
using Animancer.FSM;
using CleverCrow.Fluid.BTs.Tasks;

public abstract class CharacterState : StateBehaviour
{
    public Character character;
    public StateMachine<CharacterState> OwnerStateMachine => character.stateMachine;

    public bool IsCurrentState() => OwnerStateMachine.CurrentState == this;

    public bool TryEnterState() => OwnerStateMachine.TrySetState(this);
    public TaskStatus TryEnterAction() =>
        OwnerStateMachine.TrySetState(this) ? TaskStatus.Success : TaskStatus.Failure;

    public void ForceSetState() => OwnerStateMachine.ForceSetState(this);
    public TaskStatus ForceStateAction()
    {
        OwnerStateMachine.ForceSetState(this);
        return TaskStatus.Success;
    }

#if UNITY_EDITOR
    protected void Reset()
    {
        character = gameObject.GetComponentInParentOrChildren<Character>();
    }
#endif
}
