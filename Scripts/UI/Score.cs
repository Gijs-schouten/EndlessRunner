using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class Score : MonoBehaviour {
    UnityEngine.UI.Text score;

    void Start() {
        score = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
    }
    
    void Update() {
        StartCoroutine("ScoreTrack");
    }

    private IEnumerator ScoreTrack() {
        score.text = "Score: " + PlayerController.playerScore;
        Debug.Log("loop");
        yield return new WaitForSeconds(0.1f);
    }
}
