using UnityEngine;
using VContainer;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIModel uiModel;
    private UIView _uiView;
    private GameManager _gameManager;
    private ScoreHandler _scoreHandler;

    [Inject]
    private void Construct(GameManager gameManager, ScoreHandler scoreHandler)
    {
        _gameManager = gameManager;
        _scoreHandler = scoreHandler;
    }

    public void StartGame() => _gameManager.StartGame();

    public void RestartGame() => _gameManager.RestartGame();

    private void Awake()
    {
        _uiView = new(uiModel.mainMenu, uiModel.inGameMenu, uiModel.pauseMenu, uiModel.gameOverMenu, uiModel.scoreText, uiModel.highScoreText);
        _gameManager.OnStartGameEvent += OnStartGame;
        _gameManager.OnGameOverEvent += ShowGameOverScreen;
        _gameManager.SetTimeScale(0);
        _scoreHandler.OnScoreChangedEvent += UpdateScore;
        _scoreHandler.OnHighScoreChangedEvent += UpdateHighScore;
    }

    private void Start() => ShowMainMenu();
    
    private void OnStartGame()
    {
        _uiView.StartGame();
        _gameManager.SetTimeScale(1);
    }

    public void ShowPauseMenu()
    {
        _uiView.ShowPauseMenu();
        _gameManager.SetTimeScale(0);
    }

    public void HidePauseMenu()
    {
        _uiView.HidePauseMenu();
        _gameManager.SetTimeScale(1);
    }

    private void ShowGameOverScreen()
    {
        _uiView.ShowGameOverMenu();
        _gameManager.SetTimeScale(0);
    }

    private void UpdateScore(int score)
    {
        _uiView.UpdateScore(score);
    }

    private void UpdateHighScore(int highScore)
    {
        _uiView.UpdateHighScore(highScore);
    }

    private void ShowMainMenu()
    {
        _uiView.ShowMainMenu();
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