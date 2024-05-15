using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController: MonoBehaviour
{
    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _slider;

    [SerializeField] private const float _multiplier = 20f;

    private float _volumeValue;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandlerSliderValueChanged);
        _volumeValue = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_slider.value) * _multiplier);
    }

    private void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_slider.value) * _multiplier);
        _slider.value = Mathf.Pow(10f, _volumeValue/_multiplier);
    }

    private void HandlerSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        _mixer.SetFloat(_volumeParameter, _volumeValue);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _volumeValue);
    }
}
