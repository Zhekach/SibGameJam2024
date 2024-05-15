using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [Serializable]
    public class MoveToGoalBehaviorNode : IBehaviorNode, ISetAnimator
    {
        [SerializeField] 
        protected NavMeshAgent _agent;
        [SerializeField] 
        protected Transform _target;

        [SerializeField, Space] 
        private float _stopRadius;
        [SerializeField] 
        private float _maxAgraRadius;

        [SerializeReference, Space] 
        protected IBehaviorNode _nextNod;

        private bool _agra;
        private AnimatorController _animatorController;

        public IBehaviorNode NextNod => _nextNod;

        public virtual void Construct()
        {
            /*_agent.updateRotation = false;
            _agent.updateUpAxis = false;*/
        }

        public void SetAnimator(AnimatorController animatorController) => 
            _animatorController = animatorController;

        public virtual bool Condition()
        {
            if (_target == null)
                return false;
        
            float distanceToTarget = (_target.transform.position - _agent.transform.position).magnitude;
        
            if (_stopRadius < distanceToTarget && distanceToTarget < _maxAgraRadius)
                return true;

            return false;
        }

        public virtual void Action()
        {
            _agent.SetDestination(_target.transform.position);
            /*Vector3 direction = _agent.pathEndPosition - _agent.transform.position;
            direction.y += _agent.transform.position.y; */
            _animatorController.Move(_target.transform.position); 
        }
    }
}