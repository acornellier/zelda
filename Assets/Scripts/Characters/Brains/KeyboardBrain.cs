using UnityEngine;

public sealed class KeyboardBrain : CharacterBrain
{
    public CharacterState locomotion;
    public CharacterState attack;

    void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("attack"))
        {
            attack.TryEnterState();
        }
        else if (input != default)
        {
            character.facingDirection = input;
            character.MovementDirection = input.normalized;
            locomotion.TryEnterState();
        }
        else
        {
            character.MovementDirection = default;
            character.idle.TryEnterState();
        }
    }
}
