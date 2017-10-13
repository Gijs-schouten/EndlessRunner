using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour {
    private float backWidhth = 18.56f;
    private float backHeight = 9.99f;
    private float timeUntilSpawn;
    public float spawnCooldown = 1;

    public GameObject[] levelBlocks;
    private GameObject platform;

    private Transform cameraTransform;
    

    void Start() {
        cameraTransform = Camera.main.transform;
        platform = levelBlocks[Random.Range(0, levelBlocks.Length)];
    }

    void Update() {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0) {
            spawnPlatform();
            timeUntilSpawn = spawnCooldown;
        }

        StartCoroutine("Spawner");
    }

    private void spawnPlatform() {
        Vector3 platPos = new Vector3(Random.Range(backWidhth / 2 + cameraTransform.position.x, backWidhth + cameraTransform.position.x), Random.Range(-backHeight / 2 + 2, backHeight / 2 - 2f));
        GameObject plat = Instantiate(platform, platPos, Quaternion.identity) as GameObject;
    }

    private IEnumerator Spawner() {
        platform = levelBlocks[Random.Range(0, levelBlocks.Length)];
        yield return spawnCooldown;
    }

}
