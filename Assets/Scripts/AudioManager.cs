using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    // [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;


    public AudioClip atackSound1;
    public AudioClip atackSound2;

    public AudioClip jumpSound;
    public AudioClip damageSound;

    private void Start()
    {
        // musicSource.Play();
    }

    public void PlayAtackSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
