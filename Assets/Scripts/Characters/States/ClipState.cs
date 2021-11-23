using Animancer;
using UnityEngine;

public sealed class ClipState : CharacterState
{
    public AnimationClip animationClip;
    AnimancerState state;

    void OnEnable()
    {
        state = character.animancer.Play(animationClip);
    }

    void FixedUpdate()
    {
        character.body.velocity = default;
    }

    public override bool CanExitState => state.RemainingDuration < 0;
}
