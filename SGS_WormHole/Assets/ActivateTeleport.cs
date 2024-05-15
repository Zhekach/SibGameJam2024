using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    [SerializeField] private QuadraticCurve _quadraticCurve;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Projectile projectile))
        {
            projectile.enabled = true;
            projectile.curve = _quadraticCurve;
        }
    }
}
