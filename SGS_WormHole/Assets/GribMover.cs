using System;
using CMF;
using UnityEngine;

public class GribMover : MonoBehaviour
{
    [SerializeField] private float _force = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AdvancedWalkerController advancedWalkerController))
        {

            advancedWalkerController.jumpSpeed = _force;
            advancedWalkerController.OnJumpStart();
            advancedWalkerController.jumpSpeed = 7;
            Debug.Log("JumpPlatform");
            //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
    }
}