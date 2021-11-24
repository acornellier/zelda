using UnityEngine;

public sealed class PlayerBrain : CharacterBrain
{
    public CharacterState locomotion;
    public CharacterState attack;

    void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Heal"))
        {
            character.Health += 1;
        }

        if (Input.GetButtonDown("Attack"))
        {
            attack.TryEnterState();
        }
        else if (input != default)
        {
            character.MovementDirection = input.normalized;
            locomotion.TryEnterState();
        }
        else
        {
            character.idle.TryEnterState();
        }
    }
}
