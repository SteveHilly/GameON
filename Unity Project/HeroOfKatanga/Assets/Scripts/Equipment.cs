using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    [SerializeField]
    List<GameObject> EquiptetItems;

    [SerializeField]
    GameObject rockPosition;
    [SerializeField]
    GameObject helmetPosition;

    public void Throw()
    {
        Debug.Log("Throwing");
        GameObject rock = null;
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (EquiptetItems[i].name == "Rock")
                rock = EquiptetItems[i];
        }

        if (rock == null)
            return;

        rock.transform.parent = null;
        rock.SendMessage("SetKinematic");
        if (gameObject.transform.eulerAngles.y == 180 || gameObject.transform.eulerAngles.y == -180)
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0));
        else  
            rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0));
        RemoveItem("Rock");
    }

    void EquipItem(GameObject item)
    {
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (item.name == EquiptetItems[i].name)
                return;
        }
        EquiptetItems.Add(item);
        GameObject position = null;
        switch (item.name)
        {
            case "Rock":
                position = rockPosition;
                break;
            case "Helmet":
                position = helmetPosition;
                break;
            default:
                return;
        }
        SetItem(position, item);
    }


    void RemoveItem(string itemName)
    {
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (itemName == EquiptetItems[i].name)
            {
                if (itemName != "Rock")
                    DeleteItem(EquiptetItems[i]);
                EquiptetItems.RemoveAt(i);
                Debug.Log("Remove item");              
                return;
            }
        }
    }

    void DeleteItem(GameObject item)
    {
        Destroy(item);
    }

    public bool CheckItem(string itemName)
    {
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (EquiptetItems[i].name == itemName)
            {
                Debug.Log("Item vorhanden");
                return true;
            }
        }
        Debug.Log("Item nicht vorhanden");
        return false;
    }

    void SetItem(GameObject TargetPosition, GameObject Target)
    {
        float xPos;
        float yPos;

        Transform transformTarget = TargetPosition.transform;
        Target.transform.parent = gameObject.transform;

        yPos = transformTarget.position.y + GameObject.FindGameObjectWithTag("Player").transform.position.y;

        if (gameObject.transform.localScale.x == 1)
            xPos = transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;
        else
            xPos = -transformTarget.position.x + GameObject.FindGameObjectWithTag("Player").transform.position.x;

        Target.transform.position = new Vector3(xPos, yPos, 0);

        if (Target.name == "Rock")
            Target.SendMessage("SetKinematic");
    }
}

