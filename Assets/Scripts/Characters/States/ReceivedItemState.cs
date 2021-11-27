using UnityEngine;

public sealed class ReceivedItemState : CharacterState
{
    public AnimationClip clip;
    public SpriteRenderer receivedItemSprite;

    protected override void OnEnable()
    {
        base.OnEnable();
        character.animancer.Play(clip);
        receivedItemSprite.sprite = character.inventory.currentItem.sprite;
    }

    void OnDisable()
    {
        receivedItemSprite.sprite = null;
    }

    public override bool CanExitState => !Input.GetButtonDown("Attack");
}
