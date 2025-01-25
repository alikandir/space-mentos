using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered" + other.name);
        if (other.CompareTag("Player") && GameManager.instance.isFlying)
        {
            GameManager.instance.ReBottle();
            
        }
        
        
    }
}

