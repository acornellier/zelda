using UnityEngine;

public sealed class LoopState : CharacterState
{
    public AnimationClip clip;

    void OnEnable()
    {
        character.animancer.Play(clip);
    }

    public override bool CanExitState => false;
}
