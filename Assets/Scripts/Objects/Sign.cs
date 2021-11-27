using UnityEngine;

public class Sign : MonoBehaviour, Interactable
{
    public string dialog;

    public void Interact()
    {
        DialogController.Instance.Toggle(dialog);
    }

    public void OnOutOfRange()
    {
        DialogController.Instance.Hide();
    }
}
