using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fps60 : MonoBehaviour
{

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }
    private void Awake()
    {
        Application.targetFrameRate = 999;
    }

    private void Update()
    {
        _text.text = (1f / Time.deltaTime).ToString();
    }
}
