using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject TitersPanel;

    private void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        TitersPanel.SetActive(false);
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        TitersPanel.SetActive(false);
    }  
    public void OpenMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        TitersPanel.SetActive(false);
    }

    public void OpenTiters()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        TitersPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit pressed");
    }
}
