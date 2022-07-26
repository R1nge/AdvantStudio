using System;
using System.Collections;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score, _highScore;
    public event Action<int, int> OnScoreChangedEvent;

    private void Awake() => Load();

    private void Start() => StartCoroutine(IncreaseScore_c());

    private IEnumerator IncreaseScore_c()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(2);
            IncreaseScore(10);
        }
    }

    private void IncreaseScore(int amount)
    {
        _score += amount;
        SetHighScore();
        OnScoreChangedEvent?.Invoke(_score, _highScore);
    }

    private void SetHighScore()
    {
        if (_score <= _highScore) return;
        _highScore = _score;
        Save();
    }

    private void Load()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        OnScoreChangedEvent?.Invoke(_score, _highScore);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("HighScore", _highScore);
        PlayerPrefs.Save();
    }
}