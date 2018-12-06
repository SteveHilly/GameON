using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetItem(GameObject Target)
    {
        gameObject.transform.position = Target.transform.position + GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameObject.name == "Rock")
            SendMessage("SetKinematic");
    }

    void DeactivateItem()
    {

    }

    
}
