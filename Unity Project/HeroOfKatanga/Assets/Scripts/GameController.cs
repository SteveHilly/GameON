using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public float childCount = 0;
    static GameController gameControllerInstance;
    [SerializeField]
    int score = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (gameControllerInstance == null)
            gameControllerInstance = this;
        else
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddChild()
    {
        childCount++;
    }

    void GameEnd()
    {
        SceneManager.LoadScene("End");
        score = 0;
    }

    public float GetChildCount()
    {
        return childCount;
    }

    void AddScore(int points)
    {
        score += points;
        GameObject.FindGameObjectWithTag("Canvas").SendMessage("UpdateUI",score);
    }
}
