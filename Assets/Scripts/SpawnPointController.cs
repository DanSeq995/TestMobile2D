using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    private float speed;
    public GameObject enemy;
    public Vector2 direction;
    public void activateSpawn() {
        var enemyObj = Instantiate(enemy, transform.position, Quaternion.identity);

        if (VolumeController.isDeveloperMode){
            speed = PlayerPrefs.GetFloat("enemySpeed", 10.0f);
        } else {
            speed = 10.0f;
        }
        enemyObj.GetComponent<EnemyController>().rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
