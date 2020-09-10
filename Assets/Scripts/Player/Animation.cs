using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.Play("Impact");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.Play("JumpImpact");
    }
}
