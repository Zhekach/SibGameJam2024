using CMF;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] private PlayerHPSystem _playerHPSystem;
    [SerializeField] private AdvancedWalkerController _walkerController;

    [SerializeField] private float fallTimeNoDamage = 2f;
    [SerializeField] private float fallDamagePerSecond = 20f;

    private float fallTimer;

    [Header("Test")]
    public bool isFalling;

    private void Awake()
    {
        _playerHPSystem = GetComponent<PlayerHPSystem>();
        _walkerController = GetComponent<AdvancedWalkerController>();
    }

    // Update is called once per frame
    void Update()
    {       
        isFalling = _walkerController.GetIsFalling();

        if(isFalling == true)
        {
            fallTimer += Time.deltaTime;
        }
        else if(isFalling == false)
        {
            MakeDamage(fallTimer);
            fallTimer = 0;
        }
    }

    private void MakeDamage(float fallTime)
    {
        float damage = 0;

        float damageTime = fallTime - fallTimeNoDamage;

        if(damageTime < 0 ) return;
        else
        {
            damage = damageTime * fallDamagePerSecond;
        }

        _playerHPSystem.OnDemage.Invoke(Convert.ToInt32(damage));
    }
}
