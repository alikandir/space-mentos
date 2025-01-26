using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultTextShow : MonoBehaviour
{
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        GameManager.instance.OnMultCollected += UpdateText;
        UpdateText(GameManager.instance.bubbleMultiplierForTxt);
    }

    void UpdateText(float mult)
    {
        _text.text = "MULT x" + mult.ToString();
    }
}
