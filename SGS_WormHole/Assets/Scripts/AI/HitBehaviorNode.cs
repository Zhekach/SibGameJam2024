using System;
using UnityEngine;

namespace AI
{
    [Serializable]
    public class HitBehaviorNode : IBehaviorNode, ISetAnimator
    {
        [field: SerializeField]
        public IBehaviorNode NextNod { get; }
    
        [SerializeField] 
        protected Transform _target;
        [SerializeField] 
        protected Transform _transform;
        [SerializeField] 
        protected float _hitRadius;
        
        private AnimatorController _animatorController;

        public void Construct()
        { }

        public void SetAnimator(AnimatorController animatorController) => 
            _animatorController = animatorController;

        public bool Condition()
        {
            if (_target == null)
                return false;
        
            float distanceToTarget = (_target.transform.position - _transform.transform.position).magnitude;
        
            if (distanceToTarget < _hitRadius)
                return true;

            return false;
        }

        public void Action() => 
            _animatorController.Hit(_target);
    }
}