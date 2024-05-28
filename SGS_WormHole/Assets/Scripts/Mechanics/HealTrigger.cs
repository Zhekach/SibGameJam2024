using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    []


    private void OnTriggerStay (Collider other)
    {
        if(other.TryGetComponent(out PlayerHPSystem playerHpSystem))
        {
            playerHpSystem.OnHeal?.Invoke(10);
        }
    }
}
