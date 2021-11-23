using Animancer;

public sealed class AttackState : CharacterState
{
    public DirectionalAnimationSet animationSet;
    AnimancerState state;

    protected override void OnEnable()
    {
        base.OnEnable();
        state = character.animancer.Play(animationSet.GetClip(character.facingDirection));
    }

    void FixedUpdate()
    {
        character.body.velocity = default;
    }

    public override bool CanExitState => state.RemainingDuration < 0;
}
