using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;

    private void Start()
    {
        _background.SetActive(false);
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(false);
    }

    public void Activate()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _background.SetActive(true);
        _pauseMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    public void Deactivate()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _background.SetActive(false);
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        _pauseMenu.SetActive(true);
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