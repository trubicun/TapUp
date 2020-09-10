using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;
    private Vector2 _origDirection;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;
    private bool _isJump;

    private void Start()
    {
        _isJump = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _origDirection = Vector2.one;
        _velocity = _origDirection;
    }

    public void Jump()
    {
        _rigidbody.velocity = _speed * _velocity;
       // _direction.y *= 1.5f;
        SetJump(false);
    }

    public void RightDirection()
    {
        _velocity.x = _origDirection.x;
        SetJump(true);
    }
    public void LeftDirection()
    {
        _velocity.x = _origDirection.x * -1;
        SetJump(true);
    }

    public bool CanJump()
    {
        return _isJump;
    }

    private void SetJump(bool jumpVal)
    {
        _isJump = jumpVal;
    }

    public void Bounce( bool isReverse)
    {
        if (isReverse) ReverseDirection();
        SetJump(true);
    }


    public void SetSpeed(float speedVal)
    {
        _speed.x = speedVal;
    }

    public void SetSpeed(Vector2 speedVal)
    {
        _speed = speedVal;
    }

    public Vector2 GetSpeed()
    {
        return _speed;
    }

    public Vector2 GetDirection()
    {
        return _velocity;
    }

    private void ReverseDirection()
    {
        _velocity.x *= -1;
    }
}
