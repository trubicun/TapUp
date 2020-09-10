using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAccelerate : MonoBehaviour
{
    [SerializeField] private float _MaxSpeed = 0.1f;
    [SerializeField] private float _smoothness = 0.5f;
    private float _speed;
    private float _yPoint;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _speed = 0;
        _yPoint = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartAcc()
    {
        float _yPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        Vector2 move = Vector2.up * (_yPoint - transform.position.y) * _smoothness;
        _rigidbody.velocity += move;
    }

    public void StopAcc()
    {
        _speed = 0;
    }
}
