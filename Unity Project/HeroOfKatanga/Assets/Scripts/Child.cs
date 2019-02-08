using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour {

    [SerializeField]
    GameObject kidImage;

    public void DestroyMe()
    {
        kidImage.SetActive(true);
        Destroy(gameObject);
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("yay");
    }
}
