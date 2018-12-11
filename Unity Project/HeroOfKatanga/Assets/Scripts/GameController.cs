using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    float childCount = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
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
}
