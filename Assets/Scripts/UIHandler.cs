using TMPro;
using UnityEngine;
using VContainer;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Canvas mainMenu, inGameMenu, pauseMenu, gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    private GameManager _gameManager;
    private ScoreHandler _scoreHandler;

    [Inject]
    private void Construct(GameManager gameManager, ScoreHandler scoreHandler)
    {
        _gameManager = gameManager;
        _scoreHandler = scoreHandler;
    }

    private void Awake()
    {
        _gameManager.OnStartGameEvent += OnStartGame;
        _gameManager.OnGameOverEvent += ShowGameOverScreen;
        _gameManager.SetTimeScale(0);
        _scoreHandler.OnScoreChangedEvent += UpdateScore;
        _scoreHandler.OnHighScoreChangedEvent += UpdateHighScore;
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

    public void StartGame() => _gameManager.StartGame();

    public void RestartGame() => _gameManager.RestartGame();

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

    private void UpdateScore(int score) => scoreText.SetText(score.ToString());

    private void UpdateHighScore(int highScore) => highScoreText.SetText($"HighScore: {highScore}");

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
        _gameManager.OnStartGameEvent -= OnStartGame;
        _gameManager.OnGameOverEvent -= ShowGameOverScreen;
        _scoreHandler.OnScoreChangedEvent -= UpdateScore;
        _scoreHandler.OnHighScoreChangedEvent -= UpdateHighScore;
    }
}