using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
            audioManager.PlaySound(audioManager.parchment); // Play parchment collect sound
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
            audioManager.PlaySound(audioManager.potionCollect); // Play potion collect sound
            Destroy(collision.gameObject); // Destroy collected potion
            Destroy(collision.gameObject.transform.parent.gameObject);
        }

        if (collision.gameObject.CompareTag("EndForest"))
        {
            SceneManager.LoadSceneAsync("Transition1_2");
        }

        if (collision.gameObject.CompareTag("EndSnow"))
        {
            SceneManager.LoadSceneAsync("TransitionSnowDesert");
        }

        if (collision.gameObject.CompareTag("EndDesert"))
        {
            SceneManager.LoadSceneAsync("TransitionDesertBoss");
        }

        if (collision.gameObject.CompareTag("EndBossFight"))
        {
            SceneManager.LoadSceneAsync("EndScene");
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
