using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
        
    }
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
