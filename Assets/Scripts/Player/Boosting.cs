using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Boosting : MonoBehaviour
{
    [SerializeField] private Vector2 _power;
    [SerializeField] private float _cameraPower = 0.01f;
    [SerializeField] private float _smoothness = 1f;
    [SerializeField] private float _maxSpeed = 40f;
    [SerializeField] private float _time = 5f;
    private Vector2 _originalSpeed;
    private Vector2 _playerSpeed;
    private bool _isBoosting;
    private float _timer;
    private Jumping _jumping;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;

    private void Start()
    {
        _jumping = GetComponent<Jumping>();
        _originalSpeed = _jumping.GetSpeed();
    }

    public void Boost()
    {
        _playerSpeed = _jumping.GetSpeed();
        _timer -= Time.deltaTime;
            if (_playerSpeed.x < _maxSpeed)
            {
                _cameraNoise.m_AmplitudeGain += _cameraPower;
                _jumping.SetSpeed(_playerSpeed + _power);
                _isBoosting = true;
            }
    }
    public void ResetBoost()
    {
        _cameraNoise.m_AmplitudeGain = 0;
        _isBoosting = false;
        _jumping.SetSpeed(_originalSpeed);
    }

    public void ResetTime()
    {
        _timer = _time;
    }

    public bool isBoosting()
    {
        return _isBoosting;
    }

    public void SetPower(UnityEngine.Vector2 val)
    {
        _power = val;
    }
    public void SetCameraNoise(CinemachineBasicMultiChannelPerlin noise)
    {
        _cameraNoise = noise;
    }
}
