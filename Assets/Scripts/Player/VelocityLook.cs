using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLook : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Jumping _jumping;
    Coroutine coroutine;

    private void Start()
    {
        _jumping = GetComponent<Jumping>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float angle = SignedAngleBetween(transform.up, _rigidbody.velocity.normalized, new Vector3(0,0,1));
        if (coroutine == null) coroutine = StartCoroutine(c_Rotate(angle, 1000f));
    }

    private void FixedUpdate()
    {
        
        
       
    }

    private void LateUpdate()
    {
    }

    IEnumerator c_Rotate(float angle, float intensity)
    {
        var me = transform;
        var to = me.rotation * Quaternion.Euler(0.0f, 0.0f, angle);

        while (true)
        {
            me.rotation = Quaternion.Lerp(me.rotation, to, intensity * Time.deltaTime);

            if (Quaternion.Angle(me.rotation, to) < 0.01f)
            {
                coroutine = null;
                me.rotation = to;
                yield break;
            }

            yield return null;
        }
    }

    float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        //float angle360 =  (signed_angle + 180) % 360;


        return signed_angle;
    }
}
