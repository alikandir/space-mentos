using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenAnim : MonoBehaviour
{
    void PlayTheGame()
    {
        GameManager.instance.ResetMultiplier();
        GameManager.instance.ResetBubbleCount();
        GameManager.instance.ReBottle();
    }
}
