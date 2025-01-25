using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenAnim : MonoBehaviour
{
    void PlayTheGame()
    {
        SceneManager.LoadScene("Collect");
    }
}
