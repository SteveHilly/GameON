using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpHight = 2f;
    [SerializeField]
    float groundDistance = 0.2f;
    [SerializeField]
    bool grounded = false;

    public LayerMask ground;

    Rigidbody myRB;
    Vector3 inputs = Vector3.zero;
    private Transform groundChecker;
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
	}

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics.CheckSphere(groundChecker.position, groundDistance,ground,QueryTriggerInteraction.Ignore);



        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        Debug.Log(Input.GetAxis("Horizontal"));

        

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
