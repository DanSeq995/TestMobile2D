using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoordinator : MonoBehaviour
{
    public GameObject multiplierStar;
    public double spawnTime = 0;
    public float spawnSpeed = 2.5f;
    Vector2 playerposition; 
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
        spawnMultiplier();
        if(spawnSpeed >= 1.2){
            spawnSpeed -= 0.2f;
            print("SpawnSpeed: " + spawnSpeed);
            }
    }
    void spawnMultiplier(){
        Vector2 position;
        do{
        var number = UnityEngine.Random.Range(0,9);
        var stage = GameObject.Find("Stage");
        var stagePoints = stage.GetComponentsInChildren<SpriteRenderer>();
        position = stagePoints[number].transform.position;
        }while(playerposition == position);
        Instantiate(multiplierStar, position, Quaternion.identity);
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

    public void SetPlayerPosition(Vector2 lastPosition){
        playerposition = lastPosition;
    }
}
