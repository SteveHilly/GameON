using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTarget : MonoBehaviour {

    [SerializeField]
    GameObject actionTarget;

    public GameObject SendTarget()
    {
        return actionTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        actionTarget = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (actionTarget = collision.gameObject)
            actionTarget = null;
    }
}
