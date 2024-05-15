using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    [SerializeField] private string _volumeParametr = "MasterVolume";
    [SerializeField] private AudioMixer _audioMixer;

    void Start()
    {
        float volumeValue = PlayerPrefs.GetFloat(_volumeParametr, -8f);
        _audioMixer.SetFloat(_volumeParametr, volumeValue);
    }
}
