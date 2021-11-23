using Animancer;
using Animancer.FSM;
using UnityEngine;

public sealed class Character : MonoBehaviour
{
    public AnimancerComponent animancer;
    public CharacterState idle;
    public CharacterBrain brain;
    public Rigidbody2D body;

    public Vector2 facingDirection = Vector2.down;
    private Vector2 movementDirection;
    public Vector2 MovementDirection
    {
        get => movementDirection;
        set
        {
            movementDirection = value.normalized;
            if (movementDirection != default)
                facingDirection = movementDirection;
        }
    }

    public StateMachine<CharacterState>.WithDefault stateMachine =
        new StateMachine<CharacterState>.WithDefault();
    [SerializeField]
    private CharacterState CurrentState;

    void Awake()
    {
        stateMachine.DefaultState = idle;
    }

    void Update()
    {
        CurrentState = stateMachine.CurrentState;
    }

    public void TrySetState(CharacterState state) => stateMachine.TrySetState(state);

#if UNITY_EDITOR
    void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref animancer);
        gameObject.GetComponentInParentOrChildren(ref body);
        gameObject.GetComponentInParentOrChildren(ref brain);
        idle = gameObject.GetComponentInParentOrChildren<IdleState>();
    }
#endif
}
