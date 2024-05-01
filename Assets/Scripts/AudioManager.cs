using System.Collections;
using System.Collections.Generic;
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

    [Header("----- Enviroment -----")]
    public AudioClip chest;
    public AudioClip parchment;
    public AudioClip potionCollect;
    public AudioClip potionDrink;

    [Header("----- Walk -----")]
    public AudioClip forestWalk;
    public AudioClip snowWalk;
    public AudioClip desertWalk;

    private void Start()
    {
        backGroundSource.clip = dragonDance;
        backGroundSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
