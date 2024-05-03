using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool ControlsIsOpen = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    public GameObject controlsMenuUI;
    // public GameObject ControlsUI;
    public GameObject potionCanva;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            potionCanva.SetActive(false);
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                if (ControlsIsOpen)
                {
                    controlsMenuUI.SetActive(true);
                    pauseMenuUI.SetActive(false);
                    ControlsIsOpen = true;
                }
                else
                {
                Pause();
                }
            }
        }

        Back();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        potionCanva.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        // Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Controls()
    {
        controlsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        ControlsIsOpen = true;
        // Time.timeScale = 0f;

    }

    public void Back()
    {
        if (ControlsIsOpen){
            if(Input.GetKeyDown("mouse 0")){
                // Debug.Log("Clicou");
                controlsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
                ControlsIsOpen = false;
            }
        }
    }
}
