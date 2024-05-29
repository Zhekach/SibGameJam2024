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
        isFighting = fightController.IsFighting;

        if(other.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem) && isFighting)
        {

            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isFighting = fightController.IsFighting;

        if (collision.gameObject.TryGetComponent(out EnemyHPSystem playerHpSystem) && isFighting)
        {

            playerHpSystem.OnDemage?.Invoke(damageValue);
        }
    }
}