using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake() => _gameManager = FindObjectOfType<GameManager>();

    private void OnTriggerEnter2D(Collider2D other) => _gameManager.GameOver();
}