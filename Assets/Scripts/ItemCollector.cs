using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Image potion0;
    [SerializeField] private Image potion1;
    [SerializeField] private Image potion2;
    [SerializeField] private Sprite emptyPotion;
    private PotionScript potionScript;
    [SerializeField] private Text parchmentText;
    private List<int> potionIventory;
    private int countParchment = 0;
    private int potionUiIndex = 0;
    private int potionHeal;

    void Start()
    {
        potionUiIndex = 0;
        potionIventory = new List<int> { 0, 0, 0 };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Parchment"))
        {
            Destroy(collision.gameObject); // Destroy collected parchment
            countParchment++; // Adds 1 to the parchment count
            parchmentText.text = "x " + countParchment; // Writes quantity of parchments in the screen
        }

        if (collision.gameObject.CompareTag("Potion"))
        {
            potionScript = collision.gameObject.transform.parent.gameObject.GetComponent<PotionScript>();
            if (potionScript != null)
            {
                potionHeal = potionScript.UpdatePotionCanvas(potionUiIndex);
                potionIventory[potionUiIndex] = potionHeal;
                potionUiIndex++;
            }
            Destroy(collision.gameObject); // Destroy collected potion
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    public int getPotionHeal()
    {
        if (potionUiIndex == 0)
        {
            return 0;
        } else
        {
            potionUiIndex = potionUiIndex - 1;

            // Updating the UI potion to be an empty potion after used
            if (potionUiIndex == 0)
            {
                potion0.sprite = emptyPotion;
            }
            else if (potionUiIndex == 1)
            {
                potion1.sprite = emptyPotion;
            }
            else if (potionUiIndex == 2)
            {
                potion2.sprite = emptyPotion;
            }
            /////////
            
            return potionIventory[potionUiIndex];
        }
    }
        
}
