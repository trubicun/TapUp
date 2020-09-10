using System.Collections;
using UnityEngine;
using Cinemachine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private float _whenSpawn;
    [SerializeField] private float _whenRelease;
    [SerializeField] private float _whenJump;
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector2 _jumpSpeed;
    [SerializeField] private GameObject _floor;
    [SerializeField] private float _waitTime;
    [SerializeField] private DialogSystem _dialog;
    [SerializeField] private DialogSystem _dialog2;
    [SerializeField] private DialogSystem _dialog3;
    [SerializeField] private GameObject _suckThing;
    [SerializeField] public  ParticleSystem _fieldEffect;
    [SerializeField] public  GameObject _upFog;
    [SerializeField] public  GameObject _FirstSpawn;
    [SerializeField] public  Animator _transition;
    private int _currentSentence;
    private CinemachineVirtualCamera _cam;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private bool _isEnd;
    private bool _isTutorialEnd = false;
    private bool _isWait;

    private void Start()
    {
        _cam = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _isWait = false;
    }

    private void Update()
    {
        if (!_dialog.isEnd())
        {
            if (_currentSentence < _whenRelease)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    NextSentence();
                    if (_currentSentence == _whenSpawn)
                    {
                        _player.GetComponent<Renderer>().enabled = true;
                        _player.GetComponent<Boosting>().SetCameraNoise(_cameraNoise);
                        _dialog.UpDialogue();
                    }
                }
                if (Input.touchCount > 0)
                {
                     if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        NextSentence();
                        if (_currentSentence == _whenSpawn)
                        {
                            _player.GetComponent<Renderer>().enabled = true;
                            _player.GetComponent<Boosting>().SetCameraNoise(_cameraNoise);
                            _dialog.UpDialogue();
                        }
                    }
                }
            }
            else
            {
                if (_currentSentence == _whenRelease)
                {
                    NextSentence();
                    _player.AddComponent<Jumping>().SetSpeed(_jumpSpeed);
                    _player.AddComponent<InputManager>();
                    _player.GetComponent<Rigidbody2D>().gravityScale = 1;
                    _player.AddComponent<VelocityLook>();
                    _player.AddComponent<Collisions>();
                    _player.AddComponent<TutorialOnPlayer>();
                    _player.GetComponent<TutorialOnPlayer>().setDialogueSystem(_dialog2,_dialog3);
                    _player.GetComponent<TutorialOnPlayer>().SetSuckThing(_suckThing);
                    _player.GetComponent<TutorialOnPlayer>().SetEffect(_fieldEffect);
                    _player.GetComponent<Live>().SetSpawn(_FirstSpawn);
                } else
                {
                    if (_currentSentence == _whenJump)
                    {
                        if (_player.transform.position.y > 3)
                        {
                            if (!_isWait)
                            {
                                StartCoroutine(Wait(_waitTime));
                            }
                        }
                    } else
                    {
                        if (!_isWait)
                        {
                            StartCoroutine(Wait(_waitTime));
                        }
                    }
                }
            }
        } else
        {
            StopAllCoroutines();
            Destroy(_floor);
            _cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            _isEnd = true;
        }
        if (_isTutorialEnd)
        {
            _player.GetComponent<Jumping>().SetSpeed(_player.GetComponent<Jumping>().GetSpeed() * 1.01f);
            _upFog.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, _upFog.GetComponent<SpriteRenderer>().color.a +  0.005f);
            _cameraNoise.m_AmplitudeGain = 5;
            _transition.SetBool("IsExit", true);
        }
    }

    private void NextSentence()
    {
        _dialog.DisplayNextSentence();
        _currentSentence = _dialog.GetCurrentSentence();
    }

    IEnumerator Wait(float seconds)
    {
        _isWait = true;
        NextSentence();
        yield return new WaitForSeconds(seconds);
        _isWait = false;
    }

    public void StartEnd()
    {
        _isTutorialEnd = true;
    }
}
