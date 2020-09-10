using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    private Boosting _boosting;
    private Jumping _jumping;
    private Live _live;
    private bool _secondJump = false;
    private GameObject _secondJumpWall;

    private void Start()
    {
        _live = GetComponent<Live>();
        _boosting = GetComponent<Boosting>();
        _jumping = GetComponent<Jumping>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "JumpingWall")
        {
            _jumping.Bounce(true);
            _secondJump = false;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            _jumping.LeftDirection();
            _secondJump = false;
        }
        if (collision.gameObject.tag == "LeftWall")
        {
            _jumping.RightDirection();
            _secondJump = false;
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (_boosting.isBoosting())
            {
                _jumping.Bounce(true);
            }
            else
            {
                    if (!_secondJump)
                    {
                        _jumping.Bounce(false);
                        _secondJump = true;
                        _secondJumpWall = collision.gameObject;
                    }
                    else
                    {
                        if (collision.gameObject != _secondJumpWall)
                        {
                            _jumping.Bounce(false);
                            _secondJump = true;
                            _secondJumpWall = collision.gameObject;
                        }
                    }
            }
        }
        if (collision.gameObject.tag == "DeathWall")
        {
            GetComponent<Live>().Death();
        }
        if (collision.gameObject.tag == "SpawnWall")
        {
            _live.SetSpawn(collision.gameObject);
            _jumping.Bounce(false);
        }
    }
}
