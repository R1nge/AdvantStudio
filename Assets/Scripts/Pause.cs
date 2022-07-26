using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerMovementController movementController;

    public void OnPointerEnter(PointerEventData eventData) => movementController.canMove = false;

    public void OnPointerExit(PointerEventData eventData) => movementController.canMove = true;

    private void OnDisable() => movementController.canMove = true;
}