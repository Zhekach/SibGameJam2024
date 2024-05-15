using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPSystem : MonoBehaviour
{
    public Action<int> OnDemage;
    public Action<int> OnHeal;
    
    [SerializeField] private int _health = 100;
    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _health;
        
        OnDemage += Damage;
        OnHeal += Heal;
    }

    private void Damage(int damage)
    {
        Debug.Log("Получил дамаг");
        _health -= damage;
        
        if(_health <= 0)
            gameObject.SetActive(false);
    }

    private void Heal(int heal)
    {
        Debug.Log("Получил хил");
        _health += heal;
        
        if(_health > _maxHealth)
            _health = _maxHealth;
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
