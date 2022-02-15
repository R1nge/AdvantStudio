using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGameMenu, pauseMenu, gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _scoreHandler.OnScoreChangedEvent += UpdateScore;
        Time.timeScale = 0;
    }

    public void Play()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowGameOverScreen()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScore(int score, int highScore)
    {
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore;
    }
}