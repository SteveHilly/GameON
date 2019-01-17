using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().childCount == 3)
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("GameEnd");
        }
    }
}
