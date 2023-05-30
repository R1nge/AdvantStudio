using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float lerpDuration;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float rayDistance;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    private bool _down = true;
    private InputAction _clickAction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _clickAction = actions.FindActionMap("Game").FindAction("Click");
    }

    private void Start() => _moveDirection = _down ? Vector2.down : Vector2.up;

    private void Update()
    {
        if (_clickAction.WasPressedThisFrame())
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate() => Move();

    private void ChangeDirection()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        if (!IsGrounded()) return;
        _down = !_down;
        _moveDirection = _down ? Vector2.down : Vector2.up;
    }

    private void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection / lerpDuration);
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, rayDistance) 
               || Physics2D.Raycast(transform.position, Vector2.up, rayDistance);
    }
}