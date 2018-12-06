using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

    [SerializeField]
    //GameObject rock;
    List<GameObject> EquiptetItems;

    [SerializeField]
    GameObject rockPosition;


    private void Start()
    {
        //rock.SetActive(false);
        //EquiptetItems.Add(rock);
    }

    void Throw()
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
        rock.GetComponent<Rigidbody>().AddForce(0, 0, 10f);
        RemoveItem(rock);
    }

    void EquipItem(GameObject item)
    {
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (item.name == EquiptetItems[i].name)
                return;
        }
        EquiptetItems.Add(item);
        item.SendMessage("SetItem", rockPosition);
    }

    void RemoveItem(GameObject item)
    {
        int itemPosition = 0;
        for (int i = 0; i < EquiptetItems.Count; i++)
        {
            if (item.name == EquiptetItems[i].name)
                itemPosition = i;
        }
        EquiptetItems.RemoveAt(itemPosition);
    }
}

