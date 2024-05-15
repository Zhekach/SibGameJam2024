using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChargeSystem : MonoBehaviour
{
    //public int CountCharge { get; private set; } = 3;
    public int CountCharge = 3;
    public Action OnUsedCharge;

    private void Start()
    {
        OnUsedCharge += UseCharge;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Charge charge))
        {
            charge.gameObject.SetActive(false);
            AddCharge();
        }
    }

    private void AddCharge()
    {
        if(CountCharge < 3)
            ++CountCharge;
    }

    private void UseCharge()
    {
        Debug.Log("Воспоьзовались ChargeSystem.UseCharge");
            --CountCharge;
    }
}