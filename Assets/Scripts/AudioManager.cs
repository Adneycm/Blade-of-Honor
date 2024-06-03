using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    [Header("----- Audio Source -----")]
    [SerializeField] private AudioSource backGroundSource; // Audio source to manage background
    [SerializeField] private AudioSource sfxSource; // Audio source to manage sfx


    [Header("----- Main Menu -----")]
    public AudioClip dragonDance;
    public AudioClip lotusPond;

    [Header("----- Forest -----")]
    public AudioClip forest;

    [Header("----- Snow -----")]
    public AudioClip snow;

    [Header("----- Desert -----")]
    public AudioClip desert;

    [Header("----- Boss Fight -----")]
    public AudioClip bossFight;

    [Header("----- Player -----")]
    public AudioClip atackSound1;
    public AudioClip atackSound2;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    [Header("----- Lord Kuroshi -----")]
    public AudioClip lordKuroshiAttack;
    public AudioClip lordKuroshiAttackDistance;
    public AudioClip lordKuroshiHit;
    public AudioClip lordKuroshiDie;

    [Header("----- Enviroment -----")]
    public AudioClip chest;
    public AudioClip parchment;
    public AudioClip potionCollect;
    public AudioClip potionDrink;
    public AudioClip swordArrow;


    private static AudioManager instance;

    private void Start()
    {
        backGroundSource.clip = lotusPond;
        backGroundSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayBackground(AudioClip clip)
    {
        backGroundSource.clip = clip;
        backGroundSource.Play();
    }

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set the instance to this object and mark it as Don't Destroy On Load
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }
}
