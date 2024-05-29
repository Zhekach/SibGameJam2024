using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicsTrigger : MonoBehaviour
{
    public GameObject Comics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AdvancedWalkerController player))
        {
            Comics.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
