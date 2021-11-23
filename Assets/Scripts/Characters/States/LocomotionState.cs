using Animancer;

public sealed class LocomotionState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    public float walkSpeed;

    protected override void Update()
    {
        base.Update();
        character.animancer.Play(animationSet.GetClip(character.MovementDirection));
    }

    void FixedUpdate()
    {
        character.body.velocity = character.MovementDirection.normalized * walkSpeed;
    }
}
