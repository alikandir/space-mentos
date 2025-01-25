using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator CamAnimator;
    public GameObject mainMenu;
    public GameObject credits;
    public void Play()
    {
        CamAnimator.SetTrigger("start");
        this.gameObject.SetActive(false);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    
}
