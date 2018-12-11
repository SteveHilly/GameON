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
        float zPos;

        Transform transformTarget = Target.transform;
        gameObject.transform.parent = player.transform;

        xPos = transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;
        yPos = transformTarget.position.y + GameObject.FindGameObjectWithTag("Player").transform.position.y;
        zPos = transformTarget.position.z + GameObject.FindGameObjectWithTag("Player").transform.position.z;

        if (player.transform.eulerAngles.y == 180 || player.transform.eulerAngles.y == -180)
            xPos = -transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;

            gameObject.transform.position = new Vector3(xPos, yPos, zPos);
        //gameObject.transform.position = transformTarget.position + GameObject.FindGameObjectWithTag("Player").transform.position;

        //gameObject.transform.parent = player.transform;
        if (gameObject.name == "Rock")
            SendMessage("SetKinematic");
    }

    void DeactivateItem()
    {

    }


}
