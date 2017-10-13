using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour {
    public GameObject[] UIobj;

    void Start() {
        UIobj[0].SetActive(false);
        UIobj[1].SetActive(false);
    }

    void Update() {
        StartCoroutine("IsDead");
    }

    private IEnumerator IsDead() {
        if (!PlayerController.playerAlive) {
            UIobj[0].SetActive(true);
            UIobj[1].SetActive(true);
        }

        if(PlayerController.playerAlive == true) {
            UIobj[0].SetActive(false);
            UIobj[1].SetActive(false);
        }

        yield return new WaitForSeconds(0.1f);
    }
}

