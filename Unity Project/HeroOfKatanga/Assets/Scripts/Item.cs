using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SetItem(GameObject Target)
    {
        float xPos;
        float yPos;

        Transform transformTarget = Target.transform;
        gameObject.transform.parent = player.transform;

        yPos = transformTarget.position.y + GameObject.FindGameObjectWithTag("Player").transform.position.y;

        if (player.transform.localScale.x == 1)
            xPos = transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;
        else
            xPos = -transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;

        gameObject.transform.position = new Vector3(xPos, yPos, 0);

        if (gameObject.name == "Rock")
            SendMessage("SetKinematic");
    }

    void DeactivateItem()
    {

    }


}
