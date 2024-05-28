using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    [SerializeField] private int containingHP = 25;
    [SerializeField] private int perHealHP = 10;

    private void OnTriggerStay (Collider other)
    {
        if(other.TryGetComponent(out PlayerHPSystem playerHpSystem))
        {
            if(playerHpSystem.OnIsReadyToHeal.Invoke() == false) 
            {
                return;
            }

            int currentHP = containingHP - perHealHP;

            if(currentHP >= 0)
            {
                currentHP = perHealHP;
                containingHP -= perHealHP;
            }
            else
            {
                currentHP = containingHP;
                containingHP = 0;
            }

            playerHpSystem.OnHeal?.Invoke(currentHP);

            if(containingHP == 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}
