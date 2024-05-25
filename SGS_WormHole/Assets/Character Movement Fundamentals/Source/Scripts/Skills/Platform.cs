using System.Collections;

using UnityEngine;

namespace CMF
{
    [RequireComponent(typeof(Material))]

    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _platformDistance;
        [SerializeField] private float _defaultHeight;
        [SerializeField] private float _timeBeforeHide;
        [SerializeField] private Color _NormalColor;
        [SerializeField] private Color _TransporentColor;
        [SerializeField] private Material _material;
        
        public float LifeSeconds;
        
        public void PlacePlatform(Transform tr)
        {
            transform.position = tr.position + tr.rotation * Vector3.forward * _platformDistance + Vector3.up * _defaultHeight;
            LifeSeconds = _timeBeforeHide;

            _material.SetFloat("_Mode", 0f);
            _material.SetColor("_Color", _NormalColor);
            gameObject.SetActive(true);
            
            StartCoroutine(HideAfterDelay());
        }

        public void ShowPlatformTarget(Transform tr)
        {
            transform.position = tr.position + tr.rotation * Vector3.forward * _platformDistance + Vector3.up * _defaultHeight;

            _material.SetFloat("_Mode", 2f);
            _material.SetColor("_Color",_TransporentColor);
            gameObject.SetActive(true);
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