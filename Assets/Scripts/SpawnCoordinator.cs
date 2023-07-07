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
        InvokeRepeating("spawnMultiplier", 0f, 5f);
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
        bool[] spawnTriggers = new bool[9];
        var spawnCount = UnityEngine.Random.Range(1, 4);
        do {
            for (int i = 0; i < 9; i++) {
                spawnTriggers[i] = false;
               
            }
            for (int i = 0; i < spawnCount; i++) {
            var triggerIndex = UnityEngine.Random.Range(0, 9);
            spawnTriggers[triggerIndex] = true;
            }
            print("STO GRAN CAZZO");
            print(!checkSpawnPossibility(spawnTriggers) + "SPAWN CHECK");
        } while(!checkSpawnPossibility(spawnTriggers));
        for (var i = 0; i < 9; i++) {
            if(spawnTriggers[i]) {
                var spawnPoint = transform.GetChild(i);
                spawnPoint.GetComponent<SpawnPointController>().activateSpawn();
            }
        }

        // var spawnMax = 2;
        // for (var spawnCount = 0; spawnCount < spawnMax; spawnCount++)
        // {
        //     var spawnIndex = UnityEngine.Random.Range(0, transform.childCount);
        //     var spawnPoint = transform.GetChild(spawnIndex);
        //     spawnPoint.GetComponent<SpawnPointController>().activateSpawn();
        // }
        
        Invoke("spawnRoutine", spawnSpeed);
    }

    public void SetPlayerPosition(Vector2 lastPosition){
        playerposition = lastPosition;
    }

    public bool checkSpawnPossibility(bool[] spawnPoints){
        bool[] firstArray = spawnPoints[0..3];
        bool[] secondArray = spawnPoints[3..6];
        bool[] thirdArray = spawnPoints[6..9];
        for(int i = 0 ; i < firstArray.Length; i++){
            print(firstArray[i]);
        }
        bool[,] escapeMatrix = new bool[3,3];
        print("BRUH");
        escapeMatrix[0,0] = firstArray[0] || secondArray[0] || thirdArray[2];
        escapeMatrix[0,1] = firstArray[0] || secondArray[1] || thirdArray[2];
        escapeMatrix[0,2] = firstArray[0] || secondArray[2] || thirdArray[2];
        escapeMatrix[1,0] = firstArray[1] || secondArray[0] || thirdArray[1];
        escapeMatrix[1,1] = firstArray[1] || secondArray[1] || thirdArray[1];
        escapeMatrix[1,2] = firstArray[1] || secondArray[2] || thirdArray[1];
        escapeMatrix[2,0] = firstArray[2] || secondArray[0] || thirdArray[0];
        escapeMatrix[2,1] = firstArray[2] || secondArray[1] || thirdArray[0];
        escapeMatrix[2,2] = firstArray[2] || secondArray[2] || thirdArray[0];

        print("AAAAAAH" + escapeMatrix);
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                if (escapeMatrix[i,j] == false){
                    return true;
                }
            }
        }
        return false;
    }

}
