using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using CMF;
using UnityEditor.XR;

[RequireComponent(typeof(SpawnSystem))]

public class PlayerHPSystem : MonoBehaviour
{
    [SerializeField] private AnimationControlTest _animatorController;
    [SerializeField] private SpawnSystem _spawnSystem;
    private CharacterInput _characterInput;
    public Menu menu;
    public Action<int> OnDemage;
    public Action<int> OnHeal;
    public Func<bool> OnIsReadyToHeal;

    [SerializeField] private int _health = 100;
    [SerializeField] private float _healingTime = 2f;
    private int _maxHealth;
    private bool _isHealing;

    private void Start()
    {
        _maxHealth = _health;

        _spawnSystem = GetComponent<SpawnSystem>();
        _animatorController = GetComponent<AnimationControlTest>();
        _characterInput = GetComponent<CharacterInput>();

        OnDemage += Damage;
        OnHeal += Heal;
        OnIsReadyToHeal += CheckReadyToHeal;
    }

    private void Damage(int damage)
    {
        Debug.Log("Получил дамаг");
        _health -= damage;

        if (_health <= 0)
        {
            menu.Activate();
        }
    }

    private bool CheckReadyToHeal()
    {
        if (_isHealing == false && _characterInput.IsHealingKeyPressed() == true)
        {
            return true;
        }

        return false;
    }

    private void Heal(int heal)
    {
        Debug.Log("Получил хил");
        _isHealing = true;
        _health += heal;
        _animatorController.OnHeal?.Invoke();

        StartCoroutine(CheckHealing());

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    private IEnumerator CheckHealing()
    {
        float currentHealingTime = _healingTime;

        while (currentHealingTime > 0)
        {
            currentHealingTime -= Time.deltaTime;
            yield return null;
        }

        _isHealing = false;
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
