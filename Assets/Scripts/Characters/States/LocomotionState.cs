using Animancer;
using UnityEngine;

public class LocomotionState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    public float walkSpeed;

    bool running;

    protected override void Update()
    {
        base.Update();
        character.animancer.Play(animationSet.GetClip(character.MovementDirection));

        running = Input.GetKey(KeyCode.LeftShift);
    }

    void FixedUpdate()
    {
        character.body.velocity =
            (running ? 4 : 1) * walkSpeed * character.MovementDirection.normalized;
    }
}
