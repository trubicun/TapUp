using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class VFXJump : MonoBehaviour
{
    private Jumping _jumping;
    private ParticleSystem _particle;
    private GameObject _player;
    [SerializeField] private ParticleSystem _particle2;
    [SerializeField] private TrailRenderer _trail;
    bool _isPlay = false;
    private Touch _touch;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        transform.localScale = _player.transform.localScale * 1.2f;
        transform.position = _player.transform.localPosition - Vector3.back * 0.01f;
        if (_jumping == null)
        {
            _jumping = GameObject.FindGameObjectWithTag("Player").GetComponent<Jumping>();
        } else
        {
            if (_jumping.CanJump())
            {
                StartGlowing();
                ReloadParticles();
            }
            else
            {
                PlayParticles();
                StopGlowing();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpingWall")
        {
            ChangeColor(Color.green);
        }
        if (collision.gameObject.tag == "LeftWall")
        {
            ChangeColor(Color.green);
        }
        if (collision.gameObject.tag == "RightWall")
        {
            ChangeColor(Color.green);
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (_particle.isStopped)
            {
                ChangeColor(Color.white);
            }
        }
    }

    private void ChangeColor(Color color)
    {
        _particle.startColor = color;
        _particle2.startColor = color;
        _trail.startColor = color;
        _trail.endColor = color;
    }

    private void PlayParticles()
    {
        if (_isPlay == false)
        {
            _isPlay = true;
            _particle2.Play();
        }
    }

    private void ReloadParticles()
    {
        _isPlay = false;
    }

    private void StartGlowing()
    {
        _particle.Play();
    }
    private void StopGlowing()
    {
        _particle.Stop();
    }
}
