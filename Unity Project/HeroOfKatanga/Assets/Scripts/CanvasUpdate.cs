using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour {

    [SerializeField]
    Text scoreText;

    void UpdateUI(int score)
    {
        scoreText.text = score.ToString();
    }

}
