using System;
using System.Collections;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private float increaseInterval;
    [SerializeField] private int increaseAmount;
    private int _score, _highScore;
    public event Action<int> OnScoreChangedEvent;
    public event Action<int> OnHighScoreChangedEvent;

    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            OnScoreChangedEvent?.Invoke(_score);
        }
    }

    private int HighScore
    {
        get => _highScore;
        set
        {
            _highScore = value;
            OnHighScoreChangedEvent?.Invoke(_highScore);
        }
    }

    private void Awake() => Load();

    private void Start() => StartCoroutine(IncreaseScore_c());

    private IEnumerator IncreaseScore_c()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(increaseInterval);
            IncreaseScore(increaseAmount);
        }
    }

    private void IncreaseScore(int amount)
    {
        Score += amount;
        TrySetHighScore();
    }

    private void TrySetHighScore()
    {
        if (Score <= HighScore) return;
        HighScore = Score;
        Save();
    }

    private void Load()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        OnHighScoreChangedEvent?.Invoke(HighScore);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}