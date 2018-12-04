using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpHight = 2f;
    bool grounded = true;

    Rigidbody myRB;
    Vector3 inputs = Vector3.zero;
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void Update()
    {
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");

        if (inputs != Vector3.zero)
            transform.forward = inputs;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            myRB.AddForce(Vector3.up * Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate ()
    {
        myRB.MovePosition(myRB.position + inputs * speed * Time.fixedDeltaTime);
    }
}
