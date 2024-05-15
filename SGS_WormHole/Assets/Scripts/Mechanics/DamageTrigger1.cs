using System;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHPSystem playerHpSystem))
        {
            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerHPSystem playerHpSystem))
        {
            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }
}