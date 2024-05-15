using CMF;
using UnityEngine;
using UnityEngine.UI;

public class MouseSenseController : MonoBehaviour
{
    [SerializeField] private MouseSettings _parameterName;
    [SerializeField] private Slider _mouseSens;
    [SerializeField] private float _mouseSensVal;
    [SerializeField] private CameraMouseInput cameraMouseInput;

    private void Awake()
    {
        _mouseSens.onValueChanged.AddListener(HandlerSliderValueChanged);
        _mouseSens.value = PlayerPrefs.GetFloat(_parameterName.ToString(), 0.01f);
    }

    private void HandlerSliderValueChanged(float value)
    {
        _mouseSensVal = _mouseSens.value;
        PlayerPrefs.SetFloat(_parameterName.ToString(), _mouseSensVal);

        if(cameraMouseInput != null)
        {
            cameraMouseInput.RefreshMouseSettings();
        }
    }
}

public enum MouseSettings
{
    MouseSense,
    MouseInvertX,
    MouseInvertY
}