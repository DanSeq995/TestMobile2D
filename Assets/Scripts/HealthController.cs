using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        setHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage() {
        health--;
        if (health == 0) {
            print("Game Over");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void setHealth(){
        health = 1;
    }
}
