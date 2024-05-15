using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BtnAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float duration = 0.3f; // продолжительность анимации
    [SerializeField] private Vector3 pressedScale = new Vector3(0.9f, 0.9f, 0.9f); // размер кнопки при нажатии

    private Vector3 _originalScale; // исходный размер кнопки

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Анимация уменьшения размера кнопки при нажатии
        transform.DOScale(pressedScale, duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Анимация возвращения кнопки к исходному размеру при отпускании
        transform.DOScale(_originalScale, duration);
    }
}