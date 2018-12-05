using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpHight = 2f;
    [SerializeField]
    float groundDistance = 0.2f;
    [SerializeField]
    bool grounded = false;
    float moveDistance;

    bool moveRight = false;
    bool moveLeft = false;

    int health = 3;
    bool playerDead = false;

    [SerializeField]
    GameObject actionTrigger;
    GameObject actionTarget;


    public LayerMask ground;

    Rigidbody myRB;
    Vector3 inputs = Vector3.zero;
    private Transform groundChecker;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
    }

    private void Update()
    {
        grounded = Physics.CheckSphere(groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");

        if (moveRight)
        {
            if (moveDistance < 1)
                moveDistance += 0.05f;
        }
        else
        {
            if (moveDistance > 0)
                moveDistance -= 0.05f;
        }

        if (moveLeft)
        {
            if (moveDistance > -1)
                moveDistance -= 0.05f;
        }
        else
        {
            if (moveDistance < 0)
                moveDistance += 0.05f;
        }

        if (moveLeft & moveRight)
            moveDistance = 0f;

        if (!moveLeft && !moveRight && -0.05f < moveDistance && moveDistance < 0.05f)
            moveDistance = 0f;

        inputs.x = moveDistance;

        if (inputs != Vector3.zero)
            transform.forward = inputs;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            myRB.AddForce(Vector3.up * Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + inputs * speed * Time.fixedDeltaTime);
    }

    public void RightArrowButtonDown()
    {
        moveRight = true;
    }

    public void RightArrowButtonUp()
    {
        moveRight = false;
    }

    public void LeftArrowButtonDown()
    {
        moveLeft = true;
    }

    public void LeftArrowButtonUp()
    {
        moveLeft = false;
    }

    public void Jump()
    {
        if (grounded)
            myRB.AddForce(Vector3.up * Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    void GetHealth(int value)
    {
        health += value;
        if (health > 3)
            health = 3;
    }

    void LoseHealth(int value)
    {
        health -= value;
        if (health <= 0)
            playerDead = true;
    }

    void Dead()
    {
        //call GameController for dead function
    }

    public void Action()
    {
        if (actionTarget != null)
            Debug.Log("Target is: " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        actionTarget = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (actionTarget = other.gameObject)
            actionTarget = null;
    }
}
