using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBooster : MonoBehaviour
{
    public float bubbleMultiplier = 1;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            MentosFlight mentosFlight = other.GetComponent<MentosFlight>();
            mentosFlight.bubbleMultiplier+=bubbleMultiplier;
            Destroy(gameObject);
        }
    }
}
