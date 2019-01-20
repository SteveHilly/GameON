using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour {

    [SerializeField]
    GameObject doorTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorTarget.SetActive(false);
            gameObject.SetActive(false);
            Debug.Log("Key collectet");
        }
        else
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log("Not the Player");
        }
    }
}
