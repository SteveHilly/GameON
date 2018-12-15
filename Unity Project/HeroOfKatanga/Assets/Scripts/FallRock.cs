using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRock : MonoBehaviour {

    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage; // player loses health
            Destroy(gameObject); // rock is removed from the game
        }

        if (other.CompareTag("Delete Rock"))
        {
            Destroy(gameObject); // rock is removed to prevent tons of objects cluttering memory
        }
    }
}
