using UnityEngine;
using TMPro;
using System.Collections;

public class RoomTitle : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Display(string roomName)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayCoroutine(roomName));
    }

    IEnumerator DisplayCoroutine(string roomName)
    {
        text.enabled = true;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        text.text = roomName;
        yield return new WaitForSeconds(3f);

        yield return TextUtilities.FadeOut(text, 1f);

        text.enabled = false;
    }
}
