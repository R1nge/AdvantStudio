using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerMovementController movementController;

    public void OnPointerEnter(PointerEventData eventData) => movementController.SetCanMove(false);

    public void OnPointerExit(PointerEventData eventData) => movementController.SetCanMove(true);

    private void OnDisable() => movementController.SetCanMove(true);
}