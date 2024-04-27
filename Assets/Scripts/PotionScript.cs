using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length > 0 && spriteRenderer != null)
        {
            // Select a random sprite from the array
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
    }
}
