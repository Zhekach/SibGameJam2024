using UnityEngine;

namespace AI
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField, Space]
        private Transform _mainTransform;
        [SerializeField, Space]
        private Animator _animator;

        public void Move(Vector3 moveTo)
        {
            _animator.Play("Move");
        }

        public void Hit(Transform target)
        {
            Vector3 lookTo = target.position;
            lookTo.y = transform.position.y;
            _mainTransform.LookAt(lookTo);
            _animator.Play("Hit");
        }
    }
}