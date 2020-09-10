using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private Jumping _jumping;
    private Boosting _boosting;
    private float _jumpDelay;
    private float _boostDelay;
    private Touch _touch;

    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {
        Jump();
        Boost();
    }

    private void SetJumpDelay(float jumpRememberVal)
    {
        _jumpDelay = jumpRememberVal;
    }
    private void SetJumpDelay()
    {
        _jumpDelay -= Time.deltaTime;
    }
    private void Jump()
    {
        if (_jumping != null)
        {
            SetJumpDelay();
            if (Input.GetKeyDown(KeyCode.Mouse0) | Input.touchCount > 0) SetJumpDelay(0.01f);
            if (_jumpDelay > 0) if (_jumping.CanJump())
                {
                    _jumping.Jump();
                    SetJumpDelay(0);
                }
            SetJumpDelay();
            if (!_boosting.enabled)
            {
                if (Input.touchCount > 0)
                {
                    _touch = Input.GetTouch(0);
                    if (_touch.phase == TouchPhase.Began)
                    {
                        SetJumpDelay(0.01f);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    SetJumpDelay(0.01f);
                }
                if (_jumpDelay > 0 & _jumping.CanJump())
                {
                    _jumping.Jump();
                    SetJumpDelay(0f);
                }
            } else
            {
                if (Input.GetKey(KeyCode.Mouse0) | Input.touchCount > 0)
                {
                    SetJumpDelay(0.01f);
                }
                if (_jumpDelay > 0 & _jumping.CanJump())
                {
                    _jumping.Jump();
                }
            }

        }
        else
        {
            Debug.LogWarning("No Jump Component");
        }
    }

    private void Init()
    {
        if (TryGetComponent(out Jumping _jump))
        {
            _jumping = _jump;
        }
        if (TryGetComponent(out Boosting _boost))
        {
            _boosting = _boost;
        }
    }

    private void Boost()
    {
        if (_boosting != null)
        {
            if (_boosting.enabled == true)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (_boostDelay > 0.6f) _boosting.Boost();
                    _boostDelay += Time.deltaTime;
                }
                if (Input.touchCount > 0)
                {
                    _touch = Input.GetTouch(0);
                    if (_boostDelay > 0.6f) _boosting.Boost();
                    _boostDelay += Time.deltaTime;
                    if (_touch.phase == TouchPhase.Ended)
                    {
                        _boosting.ResetBoost();
                        _boosting.ResetTime();
                        _boostDelay = 0;
                    }
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    if (_boosting.isBoosting())
                    {
                        _boosting.ResetBoost();
                        _boosting.ResetTime();
                        _boostDelay = 0;
                    }
                }
            }
        } else
        {
            if (TryGetComponent(out Boosting _boost))
            {
                _boosting = _boost;
            }
            else
            {
                Debug.LogWarning("No Boost Component");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SetJumpDelay(0f);
        }
    }
}
