using Animancer;
using Animancer.FSM;

public abstract class CharacterState : StateBehaviour, IOwnedState<CharacterState>
{
    public Character character;
    public StateMachine<CharacterState> OwnerStateMachine => character.stateMachine;

#if UNITY_EDITOR
    protected void Reset()
    {
        character = gameObject.GetComponentInParentOrChildren<Character>();
    }
#endif
}
