using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public TextMeshProUGUI spawnSpeedUI;
    public float spawnSpeed;

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
            print("Up");
    }

    public void SpawnSpeedDown()
    {
        //if(spawnSpeed > 0) {
            spawnSpeed = spawnSpeed - 0.5f;
            PlayerPrefs.SetFloat("spawnSpeed", spawnSpeed);
            PlayerPrefs.Save();
            SetSpawnSpeed(spawnSpeed);
            print("Down");
        //}
    }

    private void SetSpawnSpeed(float spawnSpeed)
    {
        spawnSpeedUI.text = spawnSpeed.ToString();
    }
}