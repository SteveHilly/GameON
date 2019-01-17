using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpHight = 300f;
    [SerializeField]
    float groundDistance = 0.2f;
    [SerializeField]
    bool grounded = false;
    float moveDistance;
    [SerializeField]
    Text childText;
    float count;
    [SerializeField]
    TestController testController;


    bool moveRight = false;
    bool moveLeft = false;

    public float health = 3;
    bool playerDead = false;

    [SerializeField]
    GameObject actionTarget;
    [SerializeField]
    float gravityModifier = 1f;

    public Transform top_left;
    public Transform buttom_right;
    public LayerMask ground;

    //Rigidbody myRB;
    Rigidbody2D myRB;
    Vector2 inputs = Vector2.zero;
    private Transform groundChecker;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        groundChecker = transform.GetChild(0);

        if (childText != null)
            childText.text = count + "/3 Children";
    }

    private void Update()
    {
        grounded = Physics2D.OverlapArea(top_left.position, buttom_right.position, ground);

        inputs = Vector2.zero;
        inputs.x = Input.GetAxis("Horizontal");

        if (moveRight)
        {
            if (moveDistance < 1)
                moveDistance += 0.05f;
            //gameObject.transform.eulerAngles = Vector3.zero;
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
            //gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
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


    }

    void FixedUpdate()
    {
        inputs += gravityModifier * Physics2D.gravity * Time.deltaTime;
        inputs.x = moveDistance;
        //myRB.MovePosition(myRB.position + inputs * Time.fixedDeltaTime);
        testController.Move(inputs.x, false, false);
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
        {
            //myRB.AddForce(Vector2.up * Mathf.Sqrt(jumpHight * -2f * Physics2D.gravity.y), ForceMode2D.Force);
            //myRB.velocity = Vector2.up * jumpHight;
            myRB.AddForce(new Vector2(0f, jumpHight));
            Debug.Log("Jumping" + myRB.velocity + "" + jumpHight +""+ Vector2.up * jumpHight + ""+myRB);
        }
        // myRB.AddForce(Vector3.up * Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y), ForceMode.VelocityChange);

    }

    void GetHealth(float value)
    {
        health += value;
        if (health > 3)
            health = 3;
    }

    void LoseHealth(float value)
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
        //gameObject.GetComponentInChildren<ActionTarget>().
        actionTarget = gameObject.GetComponentInChildren<ActionTarget>().SendTarget();
        bool throwAction = true;
        //throwAction = gameObject.GetComponent<Equipment>().RockEquipped(throwAction);
        throwAction = gameObject.GetComponent<Equipment>().CheckItem("Rock");

        Debug.Log(throwAction);

        if (throwAction)
        {
            SendMessage("Throw");
            Debug.Log(throwAction);
            return;
        }

        if (actionTarget == null)
        {
            Debug.Log(throwAction);
            return;
        }

        //Add action depending on the actionTarget also implement layerMask to the trigger
        if (actionTarget.tag == "Item")
        {
            SendMessage("EquipItem", actionTarget);
            Debug.Log(actionTarget.name);
        }

        if (actionTarget.tag == "Ladder")
        {
            Climb();
        }

        if (actionTarget.tag == "Child")
        {
            Destroy(actionTarget);
            count++;
            GameObject.FindGameObjectWithTag("GameController").SendMessage("AddChild");
            childText.text = count + "/3 Children";
        }

        if (actionTarget.tag == "Teacher")
        {
            GameObject.FindGameObjectWithTag("Canvas").SendMessage("StartUI");
            this.enabled = false;
        }

        Debug.Log(throwAction);
    }

    void Climb()
    {
        GameObject target;
        float offset = 1f;
        float targetPositionY;
        float targetPositionX;
        Vector3 targetPosition;

        if (actionTarget.name == "Button")
            target = actionTarget.transform.parent.transform.Find("Top").gameObject;
        else
            target = actionTarget.transform.parent.transform.Find("Button").gameObject;

        if (target == null)
            return;

        targetPositionY = target.transform.position.y + offset;
        targetPositionX = target.transform.position.x;
        // targetPosition = new Vector3(gameObject.transform.position.x, targetPositionY, gameObject.transform.position.z);
        targetPosition = new Vector3(targetPositionX, targetPositionY, gameObject.transform.position.z);


        Debug.Log(targetPosition);
        myRB.position = targetPosition;

    }
}
