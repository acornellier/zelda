using UnityEngine;

public sealed class LoopState : CharacterState
{
    public AnimationClip clip;

    protected override void OnEnable()
    {
        base.OnEnable();
        character.animancer.Play(clip);
    }

    public override bool CanExitState => false;
}
