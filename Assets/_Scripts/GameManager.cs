using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float bubbleCollected = 0;
    public void ResetBubbleCount()
    {
        bubbleCollected = 0;
    }

    public float GetBubbleCollected()
    {
        return bubbleCollected; 
    }

    public void CollectBubble(float amount)
    {
        bubbleCollected += amount;
    }
}
