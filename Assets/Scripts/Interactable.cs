using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string dialog;

    static public event Action<bool> OnInteractableRange;

    bool playerInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            DialogController.Instance.ToggleText(dialog);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            OnInteractableRange?.Invoke(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            DialogController.Instance.Hide();
            OnInteractableRange?.Invoke(false);
        }
    }
}
