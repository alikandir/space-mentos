using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBooster : MonoBehaviour
{
    private float bubbleMultiplier = 0.15f;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            
            GameManager.instance.CollectMultiplier(bubbleMultiplier);
            Destroy(gameObject);
            
        }
    }
}
