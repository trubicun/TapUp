using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trai : MonoBehaviour
{
    private TrailRenderer _renderer;
    private Boosting _boosting;

    private void Start()
    {
        _renderer = GetComponent<TrailRenderer>();
        _boosting = GameObject.FindGameObjectWithTag("Player").GetComponent<Boosting>();
    }

    private void Update()
    {
        if (_boosting.isBoosting())
        {
            if (_renderer.enabled == false)
            {
                _renderer.enabled = true;
            }
        } else
        {
            if (_renderer.enabled == true)
            {
                _renderer.enabled = false;
            }
        }
    }
}
