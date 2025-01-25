using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollect : MonoBehaviour
{
    public float bubbleAmount=1f;
    public GameManager manager;
    public Camera mainCamera;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, 0));

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            transform.position = point;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
        manager.CollectBubble(bubbleAmount);
        Debug.Log("bubble collected");
        }
}
