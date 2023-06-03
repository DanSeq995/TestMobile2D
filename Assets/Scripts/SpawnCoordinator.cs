using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoordinator : MonoBehaviour
{
    // Start is called before the first frame update

    void spawnRoutine() {
        GameObject[] spawnPoints = new GameObject[] {};
       
        var spawnMax = 2;
        for(var spawnCount = 0; spawnCount < spawnMax; spawnCount++) {
            var spawnIndex = Random.Range(0, transform.childCount);
            var spawnPoint = transform.GetChild(spawnIndex);
            spawnPoint.GetComponent<SpawnPointController>().activateSpawn();
        }
    }
    void Start()
    {
        InvokeRepeating("spawnRoutine", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
