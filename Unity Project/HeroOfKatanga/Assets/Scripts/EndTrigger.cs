using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().childCount == 3)
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("GameEnd");
        }
    }
}
