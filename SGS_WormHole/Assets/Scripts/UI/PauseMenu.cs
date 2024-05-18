using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseBackground;
    public GameObject DeathBackground;
    public GameObject ResumeButton;
    public GameObject RespawnButton;
    public GameObject SettingsButton;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public SpawnSystem SpawnSystem;

    public void Activate(int health)
    {
        if(health > 0)
        {
            ResumeButton.SetActive(true);
            PauseBackground.SetActive(true);
        }
        else
        {
            DeathBackground.SetActive(true);
            RespawnButton.SetActive(true);
        }

        RestartButton.SetActive(true);
        SettingsButton.SetActive(true);
        ExitButton.SetActive(true);
    }

    public void Deactivate()
    {
        DeathBackground.SetActive(false);
        PauseBackground.SetActive(false);
        ResumeButton.SetActive(false);
        RespawnButton.SetActive(false);
        SettingsButton.SetActive(false);
        RestartButton.SetActive(false);
        ExitButton.SetActive(false);
    }
    
    public void Respawn()
    {
        SpawnSystem.OnRespawn?.Invoke();
    }
}