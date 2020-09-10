using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private DialogSystem _dialog;
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private DeathWall _deathWall;
    private Jumping _jump;
    private Boosting _boost;
    private InputManager _input;
    private GameObject _player;
    private bool isNext = false;
    private bool isEnd = false;
    private bool isSlow = false;
    private bool isFast = false;
    private bool isBoost = false;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isBoost)
        {
            _jump.Jump();
            _boost.Boost();
            
        }
        if (isFast)
        {
            if (!isSlow)
            {
                if (math.abs(_player.transform.position.y - _deathWall.transform.position.y) <= 10)
                {
                    isSlow = true;
                    _deathWall.SetSpeed(_deathWall.GetSpeed() / 1.38f);
                }
            }
        }
        if (isNext)
        {
            if (_dialog.isEnd())
            {
                if (!isEnd)
                {
                    isEnd = true;
                    StartCoroutine(Wait());
                } else
                {

                }
            }
            StartCoroutine(Wait(4f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _player.tag)
        {
            _deathWall.SetSpeed(_deathWall.GetSpeed() * 2);
            isFast = true;
            _dialog.DisplayNextSentence();
            _dialog.OpenDialogue();
            _dialog.UpDialogue();
            isNext = true;
            isBoost = true;
            _jump = _player.GetComponent<Jumping>();
            _boost = _player.GetComponent<Boosting>();
            _input = _player.GetComponent<InputManager>();
            _input.enabled = false;
        }
    }

    IEnumerator Wait(float seconds)
    {
        isNext = false;
        yield return new WaitForSeconds(seconds);
        _dialog.DisplayNextSentence();
        isNext = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8f);
        _tutorial.StartEnd();
        Jumping jumping = _player.GetComponent<Jumping>();
    }
}
