using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public TextMeshProUGUI spawnSpeedUI;
    private float spawnSpeed;

    public TextMeshProUGUI enemySpeedUI;
    private float enemySpeed;

    private void Start()
    {
        spawnSpeed = PlayerPrefs.GetFloat("spawnSpeed", 2.5f);
        SetSpawnSpeed(spawnSpeed);

        enemySpeed = PlayerPrefs.GetFloat("enemySpeed", 10.0f);
        SetEnemySpeed(enemySpeed);
    }

    public void SpawnSpeedUp()
    {
        spawnSpeed = spawnSpeed + 0.5f;
            PlayerPrefs.SetFloat("spawnSpeed", spawnSpeed);
            PlayerPrefs.Save();
            SetSpawnSpeed(spawnSpeed);
    }

    public void SpawnSpeedDown()
    {
        if(spawnSpeed > 0) {
            spawnSpeed = spawnSpeed - 0.5f;
            PlayerPrefs.SetFloat("spawnSpeed", spawnSpeed);
            PlayerPrefs.Save();
            SetSpawnSpeed(spawnSpeed);
        }
    }

    public void EnemySpeedUp()
    {
        enemySpeed++;
        PlayerPrefs.SetFloat("enemySpeed", enemySpeed);
        PlayerPrefs.Save();
        SetEnemySpeed(enemySpeed);
    }

    public void EnemySpeedDown()
    {
        if(enemySpeed > 0) {
            enemySpeed--;
            PlayerPrefs.SetFloat("enemySpeed", enemySpeed);
            PlayerPrefs.Save();
            SetEnemySpeed(enemySpeed);
        }
    }

    private void SetSpawnSpeed(float spawnSpeed)
    {
        spawnSpeedUI.text = spawnSpeed.ToString();
    }

    private void SetEnemySpeed(float enemySpeed)
    {
        enemySpeedUI.text = enemySpeed.ToString();
    }
}