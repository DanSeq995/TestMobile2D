using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public GameObject enemy;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        var enemyObj = Instantiate(enemy, transform.position, Quaternion.identity);
        var speed = enemyObj.GetComponent<EnemyController>().speed;
        enemyObj.GetComponent<EnemyController>().rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
