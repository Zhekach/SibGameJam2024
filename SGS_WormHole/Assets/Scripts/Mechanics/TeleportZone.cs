using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public bool IsPlayerZone;
    public List<GameObject> _listTeleport;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsPlayerZone)
        {
            foreach (var teleport in _listTeleport)
            {
                teleport.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Projectile projectile))
        {
            IsPlayerZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Projectile projectile))
        {
            IsPlayerZone = false;
        }
    }
}
