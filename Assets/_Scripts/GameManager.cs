using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool isCollecting = false;
    bool isFlying = false;
    [SerializeField] float collectingTime = 10f;
    float startTime;
    bool isTimerSet = false;
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

    private void Update()
    {
        if (isCollecting)
        {
            Debug.Log(Time.time +"-"+startTime);
            if (isTimerSet && Time.time - startTime > collectingTime)
            {
                SendToFlight();
            }
            if(!isTimerSet)
            {
                StartTimer();
            }
        }
        
    }

    void SendToFlight()
    {
        isCollecting = false;
        isFlying = true;
        isTimerSet = false;
        Debug.Log("Sending To Flight");
        SceneManager.LoadScene("Fly");
    }

    void StartTimer()
    {
        startTime = Time.time;
        isTimerSet = true;
    }
    
}
