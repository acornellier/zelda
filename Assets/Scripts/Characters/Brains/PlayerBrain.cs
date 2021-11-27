using UnityEngine;

public sealed class PlayerBrain : CharacterBrain
{
    public LayerMask interactableLayer;
    public CharacterState locomotion;
    public CharacterState attack;
    public CharacterState drinkPotion;
    public CharacterState receiveItem;

    void Start()
    {
        EventManager.OnItemReceived += (item) =>
        {
            character.inventory.currentItem = item;
            character.inventory.AddItem(item);
            receiveItem.ForceState();
        };
    }

    void Update()
    {
        if (DialogController.Instance.active)
        {
            if (Input.GetButtonDown("Attack"))
                DialogController.Instance.Next();
            return;
        }

        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Heal") && drinkPotion.TryEnterState())
        {
            character.Health += 1;
        }
        else if (Input.GetButtonDown("Attack"))
        {
            var interactable = CheckForInteractable();
            if (interactable != null)
                interactable.Interact();
            else
                attack.TryEnterState();
        }
        else if (input != default)
        {
            character.MovementDirection = input.normalized;
            locomotion.TryEnterState();
        }
        else
        {
            character.idle.TryEnterState();
        }
    }

    Interactable CheckForInteractable()
    {
        var collider = Physics2D.OverlapCircle(
            (Vector2)character.transform.position + character.FacingDirection,
            0.5f,
            interactableLayer
        );

        if (collider == null)
            return null;

        return collider.GetComponent<Interactable>();
    }
}
