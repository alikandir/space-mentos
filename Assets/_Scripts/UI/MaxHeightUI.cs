using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxHeightUI : MonoBehaviour
{
    TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text="Height Reached\n"+GameManager.instance.maxHeightReached.ToString("F1") + " meters";
    }

    public void OnRestartGame(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
