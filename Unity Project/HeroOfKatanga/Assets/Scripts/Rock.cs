using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Item {

    Rigidbody myRB;

    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }
    void SetKinematic()
    {
        myRB.isKinematic = !myRB.isKinematic;
    }
}
