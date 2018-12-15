using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    float childCount = 0;
    static GameController gameControllerInstance;

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
        if (childCount == 3)
            GameEnd();
    }

    void GameEnd()
    {
        SceneManager.LoadScene("End");
    }

    public float GetChildCount()
    {
        return childCount;
    }
}
