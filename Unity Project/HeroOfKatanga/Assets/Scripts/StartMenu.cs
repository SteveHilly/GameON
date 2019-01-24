using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("ClassRoom");

    }

    void Awake ()
    {
        FindObjectOfType<AudioManager>().Play("startSound"); // play sound on start
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("1Start");
    }
    public void InfoScreen()
    {
        SceneManager.LoadScene("Info");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void doExitGame()
    {
        Application.Quit();
    }
}
