using System.Collections;
using TMPro;
using UnityEngine;

public class DialogController : Singleton<DialogController>
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool active;

    public void Toggle(string text)
    {
        if (active)
            Hide();
        else
            Show(text);
    }

    public void Next()
    {
        if (active)
            Hide();
    }

    public void Show(string text)
    {
        active = true;
        dialogBox.SetActive(true);
        StartCoroutine(TypeCo(text));
    }

    IEnumerator TypeCo(string text)
    {
        dialogText.text = "";
        foreach (var letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void Hide()
    {
        active = false;
        dialogBox.SetActive(false);
    }
}
