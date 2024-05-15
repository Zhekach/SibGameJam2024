using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public QuadraticCurve curve;
    public float speed;

    private float _sampleTime;

    private void Start()
    {
        _sampleTime = 0;
    }

    private void Update()
    {
        
        
        _sampleTime += Time.deltaTime * speed;
        transform.position = curve.Evaluate(_sampleTime);
        //transform.forward = curve.Evaluate(_sampleTime + 0.001f) - transform.position;

        if (_sampleTime >= 1f)
        {
            transform.rotation = Quaternion.identity;
            enabled = false;
            _sampleTime = 0;
        }
    }
}
