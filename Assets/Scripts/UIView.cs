using TMPro;
using UnityEngine;

public class UIView
{
    private readonly Canvas _mainMenu, _inGameMenu, _pauseMenu, _gameOverMenu;
    private readonly TextMeshProUGUI _scoreText, _highScoreText;

    public UIView(Canvas mainMenu, Canvas inGameMenu, Canvas pauseMenu, Canvas gameOverMenu, TextMeshProUGUI scoreText, TextMeshProUGUI highScoreText)
    {
        _mainMenu = mainMenu;
        _inGameMenu = inGameMenu;
        _pauseMenu = pauseMenu;
        _gameOverMenu = gameOverMenu;
        _scoreText = scoreText;
        _highScoreText = highScoreText;
    }

    public void StartGame()
    {
        _mainMenu.gameObject.SetActive(false);
        _inGameMenu.gameObject.SetActive(true);
        _pauseMenu.gameObject.SetActive(false);
        _gameOverMenu.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        _scoreText.SetText(score.ToString());
    }

    public void UpdateHighScore(int newHighScore)
    {
        _highScoreText.SetText($"HighScore: {newHighScore}");
    }

    public void ShowPauseMenu()
    {
        _pauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu()
    {
        _pauseMenu.gameObject.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        _mainMenu.gameObject.SetActive(false);

        _inGameMenu.gameObject.SetActive(false);

        _pauseMenu.gameObject.SetActive(false);

        _gameOverMenu.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _inGameMenu.gameObject.SetActive(false);
        _pauseMenu.gameObject.SetActive(false);
        _gameOverMenu.gameObject.SetActive(false);
    }
}