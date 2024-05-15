using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SpawnSystem spawnSystem))
        {
            spawnSystem.OnRespawn?.Invoke();
        }
    }
}
