using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (SpawnSystem))]

public class PlayerHPSystem : MonoBehaviour
{
    [SerializeField] private AnimationControlTest _animatorController;
    [SerializeField] private SpawnSystem _spawnSystem;
    public Menu menu;
    public Action<int> OnDemage;
    public Action<int> OnHeal;
    
    [SerializeField] private int _health = 100;
    private int _maxHealth;
    //public bool IsHealing { get; private set; }
    public bool IsHealing;
    public bool isHealingTrigger;

    private void Start()
    {
        _maxHealth = _health;

        _spawnSystem = GetComponent<SpawnSystem>();
        _animatorController = GetComponent<AnimationControlTest>();
        
        OnDemage += Damage;
        OnHeal += Heal;
    }

    private void Damage(int damage)
    {
        Debug.Log("Получил дамаг");
        _health -= damage;
        
        if(_health <= 0)
        {
            menu.Activate();
        }
    }

    private void Heal(int heal)
    {
        if(IsHealing)
        {
            isHealingTrigger = true;
            return;
        }

        Debug.Log("Получил хил");
        IsHealing = true;
        _health += heal;
        _animatorController.OnHeal?.Invoke();

        StartCoroutine(CheckHealing());
        
        if(_health > _maxHealth)
            _health = _maxHealth;
    }

    private IEnumerator CheckHealing()
    {
        while (IsHealing)
        {
            IsHealing = _animatorController.GetHealAnimState();
            yield return null;
        }

        IsHealing = false;
    }

    public int GetHP()
    {
        return _health;
    }

    public int GetMaxHP()
    {
        return _maxHealth;
    }
}
