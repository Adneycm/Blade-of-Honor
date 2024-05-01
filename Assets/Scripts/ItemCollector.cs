using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private PotionScript potionScript;
    [SerializeField] private Text parchmentText;
    private int countParchment = 0;
  
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
                potionScript.UpdatePotionCanvas();
            }
            Destroy(collision.gameObject); // Destroy collected potion
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
