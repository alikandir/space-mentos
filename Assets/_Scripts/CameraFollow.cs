using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Transform cameraTransform;
    
    private void Start() {
        cameraTransform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(cameraTransform.position.x, target.position.y, cameraTransform.position.z);
    }
}
