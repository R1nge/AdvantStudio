using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGameMenu, pauseMenu, gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private ScoreHandler scoreHandler;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        scoreHandler.OnScoreChangedEvent += UpdateScore;
        gameManager.OnStartGameEvent += OnStartGame;
        gameManager.OnGameOverEvent += ShowGameOverScreen;
        gameManager.SetTimeScale(0);
    }

    private void Start() => ShowMainMenu();

    private void OnStartGame()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        gameManager.SetTimeScale(1);
    }

    public void ShowPauseMenu()
    {
        gameManager.SetTimeScale(0);
        pauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        gameManager.SetTimeScale(1);
    }

    private void ShowGameOverScreen()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        gameManager.SetTimeScale(0);
    }

    private void UpdateScore(int score, int highScore)
    {
        scoreText.SetText(score.ToString());
        highScoreText.SetText("HighScore: " + highScore);
    }

    private void ShowMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        inGameMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        gameManager.SetTimeScale(0);
    }

    private void OnDestroy()
    {
        scoreHandler.OnScoreChangedEvent -= UpdateScore;
        gameManager.OnStartGameEvent -= OnStartGame;
        gameManager.OnGameOverEvent -= ShowGameOverScreen;
    }
}