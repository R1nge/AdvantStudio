using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGameMenu, pauseMenu, gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    private ScoreHandler _scoreHandler;
    private GameManager _gameManager;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _gameManager = FindObjectOfType<GameManager>();

        _scoreHandler.OnScoreChangedEvent += UpdateScore;
        _gameManager.OnStartGameEvent += OnStartGame;
        _gameManager.OnGameOverEvent += ShowGameOverScreen;
        _gameManager.SetTimeScale(0);
    }

    private void Start() => ShowMainMenu();

    private void OnStartGame()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(false);
        _gameManager.SetTimeScale(1);
    }

    public void ShowPauseMenu()
    {
        _gameManager.SetTimeScale(0);
        pauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        _gameManager.SetTimeScale(1);
    }

    private void ShowGameOverScreen()
    {
        mainMenu.gameObject.SetActive(false);
        inGameMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        _gameManager.SetTimeScale(0);
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
        _gameManager.SetTimeScale(0);
    }

    private void OnDestroy()
    {
        _scoreHandler.OnScoreChangedEvent -= UpdateScore;
        _gameManager.OnStartGameEvent -= OnStartGame;
        _gameManager.OnGameOverEvent -= ShowGameOverScreen;
    }
}