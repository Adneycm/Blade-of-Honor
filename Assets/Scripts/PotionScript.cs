using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
    [SerializeField] private Image potion;
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

    public void UpdatePotionCanvas()
    {
        potion.sprite = sprites[potionIndex];
    }
    
}
