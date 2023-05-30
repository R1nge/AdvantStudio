using UnityEngine;
using VContainer;

public class DeadZone : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    private void OnTriggerEnter2D(Collider2D other) => _gameManager.GameOver();
}