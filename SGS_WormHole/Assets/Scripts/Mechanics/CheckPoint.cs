using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SpawnSystem spawnSystem))
        {
            spawnSystem.OnSetLastPointSpawn.Invoke(this.transform);
        }
    }
}
