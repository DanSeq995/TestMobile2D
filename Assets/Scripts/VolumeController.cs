using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public TextMeshProUGUI spawnSpeedUI;
    public float spawnSpeed = 2.5f;

    private void Start()
    {
        spawnSpeed = PlayerPrefs.GetFloat("spawnSpeed", 2.5f);
        SetSpawnSpeed(spawnSpeed);
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

    private void SetSpawnSpeed(float spawnSpeed)
    {
        spawnSpeedUI.text = spawnSpeed.ToString();
    }
}