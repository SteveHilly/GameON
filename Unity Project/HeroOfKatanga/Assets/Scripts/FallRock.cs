using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRock : MonoBehaviour
{

    public float damage = 0.5f;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage; // player loses health
            Destroy(gameObject); // rock is removed from the game
        }
       


    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().SendMessage("LoseHealth", damage);
            Debug.Log("Damage player");
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject); // rock is removed from the game
        }
        //function is called twice and I don't know why. Has something to do with the collision. Collides 2 times. Reduced the rock damage for that reason

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }


}
