using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Item
{

    Rigidbody2D myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    void SetKinematic()
    {
        myRB.isKinematic = !myRB.isKinematic;
        if (myRB.isKinematic)
        {
            myRB.velocity = Vector2.zero;
            myRB.angularVelocity = 0f;
        }

    }
}
