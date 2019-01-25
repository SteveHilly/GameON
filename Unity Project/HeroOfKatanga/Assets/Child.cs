using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour {

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("yay");
    }
}
