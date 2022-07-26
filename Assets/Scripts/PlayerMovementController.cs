using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Game is too simple, no need in property
    public bool canMove = true;
    [SerializeField] private float lerpDuration;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _down = true;

    private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Start()
    {
        canMove = true;
        _moveDirection = _down ? Vector2.down : Vector2.up;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            ChangeDirection();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate() => Move(_moveDirection, lerpDuration);

    private void ChangeDirection()
    {
        if (!_isGrounded) return;
        _moveDirection = _down ? Vector2.up : Vector2.down;
        _down = !_down;
    }

    private void Move(Vector2 direction, float lerp) =>
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction / lerp);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walkable"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walkable"))
        {
            _isGrounded = false;
        }
    }
}