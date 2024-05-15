using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _teleport; // другой телепорт
    public bool _isTeleporting;
    
    public void ActivateTeleport()
    {
        _isTeleporting = true;
    }
    
    public void DeactivateTeleport()
    {
        _isTeleporting = false;
    }

    public void DestroyTeleport()
    {
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_isTeleporting == false)
        {
            Debug.Log(other.name);
            if(other.TryGetComponent(out Projectile projectile))
            {
                other.transform.position = _teleport.transform.position;
                _teleport.ActivateTeleport();

                if (gameObject.activeSelf)
                {
                    Debug.Log("Tete");
                    _isTeleporting = false;
                    DestroyTeleport();
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isTeleporting == true)
        {
            
            if(other.TryGetComponent(out Projectile projectile))
            {
                if (_teleport.gameObject.activeSelf)
                {
                    _teleport.DeactivateTeleport();
                    _teleport.DestroyTeleport();
                }
                else
                {
                    _isTeleporting = false;
                    DestroyTeleport();
                }
            }
        }
    }
}
