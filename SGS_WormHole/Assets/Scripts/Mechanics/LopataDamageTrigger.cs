using System;
using UnityEngine;

public class LopataDamageTrigger : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;
    [SerializeField] private bool isFighting;

    private FightController fightController;

    private void Start()
    {
        fightController = GetComponentInParent<FightController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem) && isFighting)
        {
            isFighting = fightController.IsFighting;

            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem) && isFighting)
        {
            isFighting = fightController.IsFighting;

            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }
}