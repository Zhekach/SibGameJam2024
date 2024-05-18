using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Action OnSpawn;
    public Action OnRespawn;

    [SerializeField] private List<Transform> _listPointSpawn;
    [SerializeField] private Transform _lastPointSpawn;

    private PlayerHPSystem _playerHPSystem;

    private void Start()
    {
        OnRespawn += Respawn;
        _playerHPSystem = GetComponent<PlayerHPSystem>();
    }

    private void Update()
    {
        _lastPointSpawn = GetClosestSpawnPoint(transform.position);
    }

    private void Spawn()
    {
        transform.position  = _listPointSpawn[0].position;
    }

    private void Respawn()
    {
        transform.position = _lastPointSpawn.position;

        int maxHealth = _playerHPSystem.GetMaxHP();
        _playerHPSystem.OnHeal?.Invoke(maxHealth);
    }
    
    public Transform GetClosestSpawnPoint(Vector3 position)
    {
        Transform closestPoint = null;
        float minDistance = float.MaxValue;
    
        foreach (Transform point in _listPointSpawn)
        {
            float distance = Vector3.Distance(position, point.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPoint = point;
            }
        }
    
        return closestPoint;
    }
}
