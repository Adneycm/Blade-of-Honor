using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
    [SerializeField] private Image potion0;
    [SerializeField] private Image potion1;
    [SerializeField] private Image potion2;
    [SerializeField] private Sprite[] sprites;
    private int potionIndex;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length > 0 && spriteRenderer != null)
        {
            // Select a random sprite from the array
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];

            potionIndex = randomIndex;
        }
    }

    public int UpdatePotionCanvas(int potionUiIndex)
    {
        if (potionUiIndex == 0)
        {
            potion0.sprite = sprites[potionIndex];
        }
        else if (potionUiIndex == 1)
        {
            potion1.sprite = sprites[potionIndex];
        }
        else if (potionUiIndex == 2)
        {
            potion2.sprite = sprites[potionIndex];
        }


        if (potionIndex == 0)
        {
            return 10;
        }
        else if (potionIndex == 1)
        {
            return 20;
        }
        else if (potionIndex == 2)
        {
            return 50;
        } else
        {
            return 100;
        }
    }
    
}
