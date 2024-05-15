using System.Collections;

using UnityEngine;

namespace CMF
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _platformDistance;
        [SerializeField] private float _defaultHeight;
        [SerializeField] private float _timeBeforeHide;
        
        public float LifeSeconds;
        
        public void PlacePlatform(Transform tr)
        {
            transform.position = tr.position + tr.rotation * Vector3.forward * _platformDistance + Vector3.up * _defaultHeight;
            LifeSeconds = _timeBeforeHide;
            gameObject.SetActive(true);
            
            StartCoroutine(HideAfterDelay());
        }
        private IEnumerator HideAfterDelay()
        {
            while (LifeSeconds > 0)
            {
                LifeSeconds -= Time.deltaTime;
                yield return null;
            }
    
            Hide();
            LifeSeconds = 0;
        }
        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}