using System.Collections;
using TMPro;
using UnityEngine;

public class TextUtilities : MonoBehaviour
{
    public static IEnumerator FadeOut(TextMeshProUGUI text, float timeSpeed)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(
                text.color.r,
                text.color.g,
                text.color.b,
                text.color.a - (Time.deltaTime * timeSpeed)
            );
            yield return null;
        }
    }
}
