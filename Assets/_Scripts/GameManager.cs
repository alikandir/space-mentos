using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool isCollecting = false;
    public bool isFlying = false;
    [SerializeField] float collectingTime = 10f;
    float startTime;
    bool isTimerSet = false;
    public static GameManager instance;
    public bool isInBottle;
    public float bubbleMultiplierActual = 0.60f;
    public float bubbleMultiplierForTxt = 1;
    public event Action<float> OnMultCollected;
    public float maxHeightReached = 0;
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
    public void CollectMultiplier(float amount)
    {
        bubbleMultiplierActual += amount;
        bubbleMultiplierForTxt += 1;
        OnMultCollected?.Invoke(bubbleMultiplierForTxt);
    }
    public void ResetMultiplier()
    {
        bubbleMultiplierActual = 0.60f;
        bubbleMultiplierForTxt = 1;
        OnMultCollected?.Invoke(bubbleMultiplierForTxt);
    }

    private void Update()
    {
        if (isCollecting)
        {
           
            if (isTimerSet && Time.time - startTime > collectingTime)
            {
                Invoke("SendToFlight", 12f);
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
        isTimerSet = false;
        Debug.Log("Sending To Flight");
        SceneManager.LoadScene("Fly");
        
        
    }

    void StartTimer()
    {
        startTime = Time.time;
        isTimerSet = true;
    }

    public void ReBottle()
    {
        isFlying = false;
        isCollecting = true;
        isTimerSet = false;

        SceneManager.LoadScene("Collect");
        
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public float RemaningTime()
    {
        float result = collectingTime-(Time.time - startTime);
        return result > 0 ? result : 0;
    }
}
