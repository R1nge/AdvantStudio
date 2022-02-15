using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float minPositionY, maxPositionY;
    [SerializeField] private float lerpDuration;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _moveDirection = Vector2.down;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ChangeDirection();
        }
    }


    private void FixedUpdate()
    {
        Move(_moveDirection, lerpDuration);
    }

    private void ChangeDirection()
    {
        if (Math.Abs(transform.position.y - minPositionY) < 0.2f)
        {
            _moveDirection = Vector2.up;
        }

        if (Math.Abs(transform.position.y - maxPositionY) < 0.2f)
        {
            _moveDirection = Vector2.down;
        }
    }

    private void Move(Vector2 direction, float lerp)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction / lerp);
    }
}