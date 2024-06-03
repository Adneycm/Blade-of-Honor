using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void Restart()
    {
        AdsManager.Instance.interstitialAds.ShowInterstitialAd();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ActivateGameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
