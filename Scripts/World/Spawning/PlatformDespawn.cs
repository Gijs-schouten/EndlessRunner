using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawn : MonoBehaviour {
    private float backWidth = 18.56f;

    void Update () {
		if(transform.position.x < Camera.main.transform.position.x - backWidth / 2 - 1) {
            Destroy(gameObject);
        }        
	}
}
