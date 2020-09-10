using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOnPlayer : MonoBehaviour
{
    [SerializeField] private DialogSystem _dialogue;
    [SerializeField] private DialogSystem _dialogue2;
    [SerializeField] private ParticleSystem _effect;
    private GameObject _deathWall;
    private CinemachineVirtualCamera _camera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private GameObject _suckThing;
    private GameObject _field;
    private Animator _animator;
    private bool _isStart = false;
    private bool _isWait = false;
    private bool _isSucking = true;
    private bool _isCor = false;
    private bool _isAnimating = false;
    private bool _isThirdDialog = false;
    private bool _isGo = false;
    private float _suckSpeed;

    private void Start()
    {
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _suckSpeed = 0.8f;
        _field = GameObject.FindGameObjectWithTag("Field");
        _animator = GetComponent<Animator>();
        _deathWall = GameObject.FindGameObjectWithTag("DeathWall");
        _deathWall.gameObject.SetActive(false);
        _isAnimating = true;
    }

    private void Update()
    {
        if (_isStart)
        {
            _dialogue.DisplayNextSentence();
            _dialogue.OpenDialogue();
            _isStart = false;
            _isWait = true;
        }
        if (_isWait)
        {
            if (!_effect.isPlaying)
            {
                _effect.Play();
            }
            transform.position = Vector3.Lerp(transform.position, _suckThing.transform.position, 0.5f * Time.deltaTime);
            if (!_isCor)
            {
                StartCoroutine(Wait(2f));
            }
            if (_dialogue.isEnd())
            {
                if (_isSucking)
                {
                    _field.transform.position = transform.position + Vector3.forward * 3;
                    _cameraNoise.m_AmplitudeGain = 4;
                    if (_field.transform.localScale.x > 0)
                    {
                        _field.transform.localScale = new Vector3(_field.transform.localScale.x - _suckSpeed * Time.deltaTime, _field.transform.localScale.y);
                        if (_field.transform.localScale.y > 0)
                        {
                            _field.transform.localScale = new Vector3(_field.transform.localScale.x, _field.transform.localScale.y - _suckSpeed * Time.deltaTime);
                        }
                        else
                        {
                            _isSucking = false;
                            _field.active = false;
                        }
                    }
                }
                if (_isAnimating)
                {
                    _isSucking = true;
                    _animator.enabled = true;
                    _isAnimating = false;
                    StartCoroutine(WaitAnim(6f));
                }
            }
            if (_isThirdDialog)
            {
                _cameraNoise.m_AmplitudeGain = 0;
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                         _dialogue2.DisplayNextSentence();
                    }
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _dialogue2.DisplayNextSentence();
                }
                if (_dialogue2.isEnd())
                {
                    _isGo = true;
                    _isThirdDialog = false;
                }
            }
            if (_isGo)
            {
                _effect.Stop();
                _isSucking = false;
                _deathWall.gameObject.SetActive(true);
                _deathWall.gameObject.GetComponent<DeathWall>().CanLift(true);
                Destroy(GameObject.FindGameObjectWithTag("Field"));
                FindObjectOfType<TrailRenderer>().GetComponent<TrailRenderer>().enabled = true;
                GetComponent<InputManager>().enabled = true;
                GetComponent<Rigidbody2D>().gravityScale = 1f;
                GetComponent<Boosting>().enabled = true;
                Destroy(GameObject.Find("FieldFloor"));
                _isGo = false;
                _isWait = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            GetComponent<InputManager>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            _isStart = true;
            _isSucking = true;
        }
    }

    public void setDialogueSystem(DialogSystem system1, DialogSystem system2)
    {
        _dialogue = system1;
        _dialogue2 = system2;
    }

    public void SetSuckThing(GameObject obj)
    {
        _suckThing = obj;
    }

    public void SetEffect(ParticleSystem effect)
    {
        _effect = effect;
    }
    IEnumerator Wait(float seconds)
    {
        _isCor = true;
        yield return new WaitForSeconds(seconds);
        _dialogue.DisplayNextSentence();
        if (!_dialogue.isEnd())
        {
            _isCor = false;
        }
    }
    IEnumerator WaitAnim(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _animator.SetBool("isPowerUp", false);
        _animator.enabled = false;
        _dialogue2.DisplayNextSentence();
        _dialogue2.OpenDialogue();
        _isThirdDialog = true;
    }
}
