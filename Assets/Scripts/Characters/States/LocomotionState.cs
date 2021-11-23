using Animancer;

public sealed class LocomotionState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    public float walkSpeed;

    private void Update()
    {
        character.animancer.Play(animationSet.GetClip(character.MovementDirection));
    }

    private void FixedUpdate()
    {
        character.body.velocity = character.MovementDirection.normalized * walkSpeed;
    }
}
