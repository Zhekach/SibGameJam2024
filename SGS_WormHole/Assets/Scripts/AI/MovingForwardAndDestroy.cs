using System;
using System.Collections;
using UnityEngine;

namespace AI
{
    public class MovingForwardAndDestroy : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private void Awake() => 
            StartCoroutine(DestroyByTimer());

        private void OnCollisionEnter(Collision other) => 
            Destroy(gameObject);

        private void Update() => 
            transform.position += transform.forward * _speed * Time.deltaTime;

        private IEnumerator DestroyByTimer()
        {
            yield return new WaitForSeconds(8);
        }
    }
}