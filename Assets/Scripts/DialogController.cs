using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    protected static DialogController instance;
    public static DialogController Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<DialogController>();

            if (instance != null)
                return instance;

            throw new System.Exception("Could not find Dialog Controller");
        }
    }

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public void ToggleText(string text)
    {
        if (dialogBox.activeInHierarchy)
        {
            Hide();
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.text = text;
        }
    }

    public void Hide()
    {
        dialogBox.SetActive(false);
    }
}
