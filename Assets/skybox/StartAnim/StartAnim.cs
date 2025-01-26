using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnim : MonoBehaviour
{
    void JumpMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
