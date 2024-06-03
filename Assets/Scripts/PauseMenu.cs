using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool ControlsIsOpen = false;
    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    public GameObject potionCanva;

    void Update()
    {
        Back();
    }

    public void TogglePause()
    {
        potionCanva.SetActive(false);
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
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
        Application.Quit();
    }

    public void Controls()
    {
        controlsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        ControlsIsOpen = true;
    }

    public void Back()
    {
        if (ControlsIsOpen)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                controlsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
                ControlsIsOpen = false;
            }
        }
    }
}