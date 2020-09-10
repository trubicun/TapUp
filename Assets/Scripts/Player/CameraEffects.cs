using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private Jumping _jumping;
    private CinemachineVirtualCamera _camera;

    private void Start()
    {
        _jumping = GetComponent<Jumping>();
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
