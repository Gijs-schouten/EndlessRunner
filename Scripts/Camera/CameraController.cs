using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Transform cameraTransform;
    private Transform playerTransform;

    void Start() {
        cameraTransform = Camera.main.transform;
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update() {
        cameraTransform.transform.position = new Vector3(playerTransform.position.x + 3, gameObject.transform.position.y, gameObject.transform.position.z);


    }
    
}
