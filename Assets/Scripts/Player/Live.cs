using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] private ParticleSystem _EmissionEffect;
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private DeathWall _deathWall;
    [SerializeField] private float _deathTime = 5;
    private GameObject _spawnWall;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Death()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        var em = _EmissionEffect.emission;
        em.enabled = false;
        _trail.GetComponent<TrailRenderer>().enabled = false;
        _spriteRenderer.enabled = false;
        _deathEffect.Play();
        _deathWall.Stop();
        StartCoroutine(Respawn(_deathTime));
    }

    public void Alive()
    {
        _deathWall.Respawn();
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        var em = _EmissionEffect.emission;
        em.enabled = true;
        _trail.GetComponent<TrailRenderer>().enabled = true;
        _spriteRenderer.enabled = true;
        transform.position = _spawnWall.transform.position + Vector3.up;
    }

    public void SetSpawn(GameObject spawn)
    {
        _spawnWall = spawn;
    }

    IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        Alive();
    }
}
