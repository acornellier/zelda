using UnityEngine;

public sealed class IdleState : CharacterState
{
    [SerializeField] private AnimationClip _Animation;

    private void OnEnable()
    {
        Character.animancer.Play(_Animation, 0.25f);
    }

    private void FixedUpdate()
    {
        Character.body.velocity = default;
    }

}
