using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame(){
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void RetryGame(){
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("HomeScene");
    }
}
