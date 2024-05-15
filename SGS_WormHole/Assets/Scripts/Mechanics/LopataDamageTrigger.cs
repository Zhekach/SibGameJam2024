using System;
using UnityEngine;

public class LopataDamageTrigger : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem))
        {
            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem))
        {
            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }
}