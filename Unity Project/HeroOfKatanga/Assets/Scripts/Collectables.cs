using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectablesTrigger")
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("AddScore", 1);
            Destroy(gameObject);
        }
    }
}
