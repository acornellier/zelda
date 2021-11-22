using Animancer;
using Animancer.FSM;
using UnityEngine;

[AddComponentMenu(Strings.ExamplesMenuPrefix + "Characters - Character")]
public sealed class Character : MonoBehaviour
{
    public AnimancerComponent animancer;
    public CharacterState idle;
    [System.NonSerialized] public Rigidbody2D body; public readonly StateMachine<CharacterState>.WithDefault StateMachine = new StateMachine<CharacterState>.WithDefault();

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        StateMachine.DefaultState = idle;
    }

    public void TrySetState(CharacterState state) => StateMachine.TrySetState(state);
}
