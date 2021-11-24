using Animancer;
using UnityEngine;

public sealed class IdleState : CharacterState
{
    [SerializeField]
    private DirectionalAnimationSet animationSet;

    protected override void Update()
    {
        base.Update();
        character.animancer.Play(animationSet.GetClip(character.FacingDirection));
    }

    void FixedUpdate()
    {
        character.body.velocity = default;
    }
}
