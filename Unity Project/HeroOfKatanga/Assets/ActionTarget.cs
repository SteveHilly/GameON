using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTarget : MonoBehaviour {

    [SerializeField]
    GameObject actionTarget;

    private void OnTriggerEnter(Collider other)
    {
        actionTarget = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (actionTarget = other.gameObject)
            actionTarget = null;
    }

    public GameObject SendTarget()
    {
        return actionTarget;
    }
}
