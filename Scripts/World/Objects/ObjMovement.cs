using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour {
    public float moveSpeed = 2;

	 void Update () {
        gameObject.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
	}
}
