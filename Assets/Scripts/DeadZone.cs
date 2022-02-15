using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private UIHandler _uiHandler;

    private void Awake()
    {
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _uiHandler.ShowGameOverScreen();
    }
}