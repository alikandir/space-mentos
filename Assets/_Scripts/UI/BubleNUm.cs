using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubleNUm : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = GameManager.instance.bubbleCollected.ToString("F0");
    }
}
