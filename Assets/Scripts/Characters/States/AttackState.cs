using Animancer;

public sealed class AttackState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    AnimancerState state;

    void OnEnable()
    {
        state = character.animancer.Play(animationSet.GetClip(character.brain.facingDirection));
    }

    void FixedUpdate()
    {
        character.body.velocity = default;
    }

    public override bool CanExitState => state.RemainingDuration < 0;
}
