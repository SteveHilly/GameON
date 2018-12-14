using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Start");
    }
}
