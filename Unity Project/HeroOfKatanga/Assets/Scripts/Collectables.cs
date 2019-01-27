using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("AddScore", 1);
            GameObject.FindWithTag("Audio").GetComponent<AudioManager>().Play("pick");
            Destroy(gameObject);
        }
    }
}
