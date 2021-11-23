using Animancer;
using UnityEngine;

public sealed class IdleState : CharacterState
{
    [SerializeField]
    private DirectionalAnimationSet animationSet;

    private void Update()
    {
        character.animancer.Play(animationSet.GetClip(character.facingDirection));
    }

    private void FixedUpdate()
    {
        character.body.velocity = default;
    }
}
