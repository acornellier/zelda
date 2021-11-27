using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject heartObject;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;

    Character player;
    readonly List<Image> heartImages = new List<Image>();
    Sprite[] orderedHeartSprites;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        orderedHeartSprites = new Sprite[5]
        {
            emptyHeart,
            quarterHeart,
            halfHeart,
            threeQuarterHeart,
            fullHeart
        };
    }

    void Start()
    {
        player.OnHealthChanged += UpdateHealth;

        for (int i = 0; i < player.MaxHealth; ++i)
        {
            var newObject = Instantiate(heartObject, gameObject.transform);
            var image = newObject.GetComponent<Image>();
            image.sprite = fullHeart;
            heartImages.Add(image);
        }
    }

    void UpdateHealth(float oldHealth, float newHealth)
    {
        var min = Mathf.Min(oldHealth, newHealth);
        var max = Mathf.Max(oldHealth, newHealth);

        for (int i = Mathf.FloorToInt(min); i < Mathf.CeilToInt(max); ++i)
        {
            heartImages[i].sprite = orderedHeartSprites[
                Mathf.CeilToInt(Mathf.Clamp01(newHealth - i) * 4)
            ];
        }
    }
}
