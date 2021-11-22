using Animancer.FSM;
using UnityEngine;

public sealed class KeyboardBrain : CharacterBrain
{
    public CharacterState locomotion;
    public CharacterState attack;

    private void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("attack"))
        {
            attack.TryEnterState();
        }
        else if (input != default)
        {
            facingDirection = input;
            movementDirection = input.normalized;
            locomotion.TryEnterState();
        }
        else
        {
            movementDirection = default;
            character.idle.TryEnterState();
        }
    }
}
