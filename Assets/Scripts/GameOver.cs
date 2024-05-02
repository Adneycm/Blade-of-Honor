using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen; // Referência ao objeto da tela de Game Over

    private void Start()
    {
        // Desativa a tela de Game Over no início
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        // Se pressionar a tecla 'P', ativa a tela de Game Over
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateGameOverScreen();
        }
    }

    // Função para ativar a tela de Game Over
    public void ActivateGameOverScreen()
    {
        // Pausa o tempo e ativa a tela de Game Over
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    // Função para reiniciar o jogo
    public void RestartGame()
    {
        // Reinicia o tempo e recarrega a cena atual
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Função para retornar ao menu principal
    public void ReturnToMenu()
    {
        // Reinicia o tempo e carrega a cena do menu principal
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
