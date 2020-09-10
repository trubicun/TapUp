using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactOnPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private float _timeSpeed;
    private Rigidbody2D _playerRigidbody;
    private Vector3 _position;

    private void Start()
    {
        _position = transform.position;
        _playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _timeSpeed += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, _position, _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_timeSpeed > 0)
        {
            _timeSpeed = -0.2f;
            transform.position = Vector3.Lerp(transform.position, (Vector2)transform.position + _playerRigidbody.velocity.normalized, _speed * 3);
        }
    }
}
