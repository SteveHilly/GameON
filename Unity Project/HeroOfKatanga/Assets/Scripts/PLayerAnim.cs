﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnim : MonoBehaviour {

    public void EndJump()
    {
        gameObject.GetComponent<Animator>().SetBool("Jumping", false);
    }

    public void JumpStart()
    {
        GameObject.FindGameObjectWithTag("Player").SendMessage("AddJumpForce");
    }
}