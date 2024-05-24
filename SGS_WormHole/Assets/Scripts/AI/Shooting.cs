using System;
using UnityEngine;

namespace AI
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _gun;
        
        public void Shot() => 
            Instantiate(_prefab, _gun.position, _gun.rotation)
                .transform
                .LookAt(_target.position);
    }
}