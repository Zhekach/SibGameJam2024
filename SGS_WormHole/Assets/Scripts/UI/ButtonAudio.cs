using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler //IPointerExitHandler
{
    [SerializeField] private AudioSource mouseEnteredAudio;
    [SerializeField] private AudioSource mouseOnClickAudio;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouseEnteredAudio.Play();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        mouseOnClickAudio.Play();
    }
}