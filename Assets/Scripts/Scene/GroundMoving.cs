using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MeshRenderer _renderer;
    private float x_Scroll;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
       Scroll();
    }

    private void Scroll()
    {
        x_Scroll = Time.time * _speed;
        Vector2 offset = new Vector2(0f, x_Scroll);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex",offset);
    }
}
