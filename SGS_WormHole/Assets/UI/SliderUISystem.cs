using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderUISystem : MonoBehaviour
{
    [SerializeField] private GameObject _uiElement;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private bool isFinalComics;
    private int _index;
    
    private void Start()
    {
        _index = 0;
        _image.sprite = _sprites[_index];
    }
    
    public void SwitchImage()
    {
        // Деактивируем текущее изображение
        _image.sprite = _sprites[_index];

        // Увеличиваем индекс на 1
        _index++;

        // Если индекс больше или равен количеству изображений, сбрасываем его на 0
        if (_index >= _sprites.Count)
        {
            _index = 0;

            if(isFinalComics)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
                return;
            }
            
            if(_uiElement != null)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _uiElement.SetActive(false);
            }
        }

        // Активируем следующее изображение
        _image.sprite = _sprites[_index];
    }
}
