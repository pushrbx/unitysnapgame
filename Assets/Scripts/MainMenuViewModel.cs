using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// ReSharper disable CheckNamespace

public class MainMenuViewModel : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnSettingsButtonClicked()
    {
        //SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
