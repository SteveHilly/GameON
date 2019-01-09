using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    [SerializeField]
    //GameObject rock;
    List<GameObject> EquiptetItems;

    [SerializeField]
    GameObject rockPosition;
    [SerializeField]
    GameObject helmetPosition;


    private void Start()
    {
        //rock.SetActive(false);
        //EquiptetItems.Add(rock);
    }

    public void Throw()
    {
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
            rock.GetComponent<Rigidbody>().AddForce(-500f, 0, 0);
        //rock.GetComponent<Rigidbody>().AddRelativeForce(250f, 0, 0);
        else   //rock.GetComponent<Rigidbody>().AddForce(-250f, 0, 0);
            rock.GetComponent<Rigidbody>().AddForce(500f, 0, 0);
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
        item.SendMessage("SetItem", position);
    }

    /*void RemoveItem(GameObject item)
    {
        int itemPosition = 0;
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (item.name == EquiptetItems[i].name)
                itemPosition = i;
        }
        EquiptetItems.RemoveAt(itemPosition);
    }*/

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

    /*public bool RockEquipped(bool equipped)
    {
        GameObject rock = null;
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (EquiptetItems[i].name == "Rock")
                rock = EquiptetItems[i];
        }


        if (rock == null)
        {
            equipped = false;           
        }
        else
        {
            equipped = true;
        }
        return equipped;
    }*/

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
}

