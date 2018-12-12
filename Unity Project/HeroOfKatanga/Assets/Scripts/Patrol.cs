using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float moveSpeed;
    float golemHealth = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);

        if (golemHealth == 0)
        {
            Destroy(gameObject); // destroy the golem
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Block")
        {
            moveSpeed *= -1; // Move the other way when collides with the wall
        }

        if(col.gameObject.tag == "Item")
        {
            golemHealth =- 1; // golem dies when it collides with a thrown rock (is tagged as "Item")
        }
    }
}
