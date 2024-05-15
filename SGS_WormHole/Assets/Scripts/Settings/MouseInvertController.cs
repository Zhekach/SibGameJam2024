using CMF;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseInvertController : MonoBehaviour
{
    [SerializeField] private MouseSettings _parameterName;
    [SerializeField] private CameraMouseInput cameraMouseInput;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(_parameterName.ToString(), 0));
    }

    private void Start()
    {
        _toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(_parameterName.ToString(),0 ));
    }

    public void ChangedValue()
    {
        if(_toggle.isOn==true)
        {
            PlayerPrefs.SetInt(_parameterName.ToString(), 1);

            if (cameraMouseInput != null)
            {
                cameraMouseInput.RefreshMouseSettings();
            }
        }
        else
        {
            PlayerPrefs.SetInt(_parameterName.ToString(), 0);

            if (cameraMouseInput != null)
            {
                cameraMouseInput.RefreshMouseSettings();
            }
        }
        Debug.Log("Toggle is Changed");
    }
}