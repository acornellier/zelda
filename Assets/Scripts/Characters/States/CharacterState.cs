using Animancer;
using Animancer.FSM;
using UnityEngine;

public abstract class CharacterState : StateBehaviour, IOwnedState<CharacterState>
{
    [SerializeField]
    private Character character;

    public Character Character
    {
        get => character;
        set
        {
            if (character != null &&
                character.StateMachine.CurrentState == this)
            {
                character.idle.ForceEnterState();
            }

            character = value;
        }
    }

    public StateMachine<CharacterState> OwnerStateMachine => character.StateMachine;

#if UNITY_EDITOR
    protected void Reset()
    {
        character = gameObject.GetComponentInParentOrChildren<Character>();
    }
#endif
}
