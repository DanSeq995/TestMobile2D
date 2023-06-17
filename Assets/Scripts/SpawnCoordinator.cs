using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoordinator : MonoBehaviour
{
    public double spawnTime = 0;
    public float spawnSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("difficultyChange", 0f, 10f);
        spawnRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
    }

    void difficultyChange(){
        if(spawnSpeed >= 1.2){
            spawnSpeed -= 0.2f;
            print("SpawnSpeed: " + spawnSpeed);
            }
    }
    void spawnRoutine()
    {
        GameObject[] spawnPoints = new GameObject[] { };

        var spawnMax = 2;
        for (var spawnCount = 0; spawnCount < spawnMax; spawnCount++)
        {
            var spawnIndex = UnityEngine.Random.Range(0, transform.childCount);
            var spawnPoint = transform.GetChild(spawnIndex);
            spawnPoint.GetComponent<SpawnPointController>().activateSpawn();
        }
        Invoke("spawnRoutine", spawnSpeed);
    }
}
