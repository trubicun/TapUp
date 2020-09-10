using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _spawnPont;
    private GameObject _background;
    private bool _isLift;

    private void Start()
    {
        _isLift = false;
        _spawnPont = transform.position;
    }

    private void Update()
    {
        //_background.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.black,Color.red,); 
        if (_isLift)
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
    }

    public void CanLift(bool val)
    {
        _isLift = val;
    }

    public void SetSpeed(float val)
    {
        _speed = val;
    }
    public float GetSpeed()
    {
        return _speed;
    }

    public void Stop()
    {
        _isLift = false;
    }

    public void Respawn()
    {
        transform.position = _spawnPont;
        _isLift = true;
    }
}
