using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectTotalUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    void Start()
    {
        _text   = GetComponent<TextMeshProUGUI>();
        SetText();
    }
    void SetText()
    {
        float bubbleCollected=GameManager.instance.GetBubbleCollected();
        float mult=GameManager.instance.bubbleMultiplierForTxt;
        _text.text = (bubbleCollected*mult).ToString();
    }

    
}
