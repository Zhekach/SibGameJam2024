using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerHPSystem playerHpSystem))
        {
            playerHpSystem.OnHeal?.Invoke(10);
        }
    }
}
