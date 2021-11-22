using Animancer;

public sealed class LocomotionState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    public float walkSpeed;

    private void Update()
    {
        character.animancer.Play(animationSet.GetClip(character.brain.movementDirection));
    }

    private void FixedUpdate()
    {
        character.body.velocity = character.brain.movementDirection * walkSpeed;
    }
}
