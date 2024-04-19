using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("OptionsScene");
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void MusicOnOff()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}