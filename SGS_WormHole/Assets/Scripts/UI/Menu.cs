using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private PlayerHPSystem playerHPSystem;

    [SerializeField] private GameObject _background;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;

    private int _health;

    private void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        _health = playerHPSystem.GetHP();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _background.SetActive(true);
        _pauseMenu.Activate(_health);
        _settingsMenu.SetActive(false);
    }

    public void Deactivate()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _background.SetActive(false);
        _pauseMenu.Deactivate();
        _settingsMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        _pauseMenu.Deactivate();
        _settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        _pauseMenu.Activate(_health);
        _settingsMenu.SetActive(false);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}