using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
            Debug.Log("Player is in collider");
        }
        else
            Debug.Log("Not the player");
    }
}
