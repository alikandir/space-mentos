using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.ReBottle();
    }
}

