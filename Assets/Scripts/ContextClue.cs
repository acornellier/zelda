using UnityEngine;

public class ContextClue : MonoBehaviour
{
    void Awake()
    {
        Interactable.OnInteractableRange += OnInteractableRange;
        gameObject.SetActive(false);
    }

    void OnInteractableRange(bool inRange)
    {
        gameObject.SetActive(inRange);
    }
}
