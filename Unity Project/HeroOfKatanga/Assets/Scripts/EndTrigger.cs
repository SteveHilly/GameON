using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string activeScene;
        activeScene = SceneManager.GetActiveScene().name;
        Debug.Log(activeScene);
        if (activeScene == "FirstMineLevel")
            if (collision.CompareTag("Player") && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().childCount == 3)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().finishedMines = true;
                SceneManager.LoadScene("ClassRoom");
            }
        if (activeScene == "SchoolLevel1")
            if (collision.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("GameController").SendMessage("GameEnd");
            }
    }
}
