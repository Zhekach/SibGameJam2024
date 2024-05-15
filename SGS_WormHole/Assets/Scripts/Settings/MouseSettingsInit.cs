using System;
using UnityEngine;

public class MouseSettingsInit : MonoBehaviour
{
    [SerializeField] private float _mouseSenseBase = 0.01f;
    [SerializeField] private int _mouseInvertBaseBool = 0;

    private MouseSettings _mouseSense = MouseSettings.MouseSense;
    private MouseSettings _mouseInvertX = MouseSettings.MouseInvertX;
    private MouseSettings _mouseInvertY = MouseSettings.MouseInvertY;

    void Awake()
    {
        //WebGLInput.captureAllKeyboardInput = true;
        Cursor.visible = false;
        
        
        float mouseSense = PlayerPrefs.GetFloat(_mouseSense.ToString(), _mouseSenseBase);
        PlayerPrefs.SetFloat(_mouseSense.ToString(), mouseSense);

        bool mouseInvertX = Convert.ToBoolean(PlayerPrefs.GetInt(_mouseInvertX.ToString(), _mouseInvertBaseBool));
        PlayerPrefs.SetInt(_mouseInvertX.ToString(), Convert.ToInt32(mouseInvertX));

        bool mouseInvertY = Convert.ToBoolean(PlayerPrefs.GetInt(_mouseInvertY.ToString(), _mouseInvertBaseBool));
        PlayerPrefs.SetInt(_mouseInvertY.ToString(), Convert.ToInt32(mouseInvertY));
    }
}