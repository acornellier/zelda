using Animancer;
using Animancer.FSM;
using UnityEngine;

public sealed class Character : MonoBehaviour
{
    public AnimancerComponent animancer;
    public CharacterState idle;
    public CharacterBrain brain;
    public Rigidbody2D body;

    public StateMachine<CharacterState>.WithDefault stateMachine =
        new StateMachine<CharacterState>.WithDefault();

    private void Awake()
    {
        stateMachine.DefaultState = idle;
    }

    public void TrySetState(CharacterState state) => stateMachine.TrySetState(state);

#if UNITY_EDITOR
    void Reset()
    {
        animancer = gameObject.GetComponentInParentOrChildren<AnimancerComponent>();
        body = gameObject.GetComponentInParentOrChildren<Rigidbody2D>();
        brain = gameObject.GetComponentInParentOrChildren<CharacterBrain>();
        idle = gameObject.GetComponentInParentOrChildren<IdleState>();
    }
#endif
}
