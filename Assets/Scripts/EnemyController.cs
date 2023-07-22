using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.2f;

    public Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        //speed = PlayerPrefs.GetFloat("enemySpeed", 10.0f);
        Invoke("destroyEnemy", 3f);
    }
    void destroyEnemy() {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
