using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRock : MonoBehaviour
{

    public float damage = 1f;

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

            if (!CheckForHelmet(collision.gameObject))
            {
                collision.gameObject.GetComponent<PlayerController>().SendMessage("LoseHealth", damage);
                Debug.Log("Damage player");
                Debug.Log(collision.gameObject.name);
                damage = 0f;
            }
            else
            {
                collision.gameObject.GetComponent<Equipment>().SendMessage("RemoveItem", "Helmet");
                damage = 0f;
            }

            Destroy(gameObject);

        }
        //function is called twice and I don't know why. Has something to do with the collision. Collides 2 times. On second collision the rock does 0 dmg

    }

    private bool CheckForHelmet(GameObject target)
    {
        bool a = false;
        a = target.GetComponent<Equipment>().CheckItem("Helmet");
        Debug.Log(a);
        return a;
    }

}
