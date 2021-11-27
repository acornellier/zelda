using UnityEngine;
using Animancer;

public class TreasureChest : MonoBehaviour, Interactable
{
    public AnimationClip openClip;
    public Item contents;
    public bool open;
    public AnimancerComponent animancer;

    public void Interact()
    {
        if (!open)
        {
            animancer.Play(openClip);
            DialogController.Instance.Show($"You found {contents.description}!");
            EventManager.ItemReceived(contents);
            open = true;
        }
        else
        {
            DialogController.Instance.Hide();
        }
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        gameObject.GetComponentInParentOrChildren(ref animancer);
    }
#endif
}
