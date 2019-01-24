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
}
