using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public TextMeshProUGUI volumeUI;
    private int volume = 0;

    private void Start()
    {
        volume = PlayerPrefs.GetInt("Volume", 0);
        SetVolume(volume);
    }

    public void VolumeUp()
    {
        volume++;
        PlayerPrefs.SetInt("Volume", volume);
        PlayerPrefs.Save();
        SetVolume(volume);
    }

    public void VolumeDown()
    {
        if(volume > 0) {
            volume--;
            PlayerPrefs.SetInt("Volume", volume);
            SetVolume(volume);
        }
    }

    private void SetVolume(int volume)
    {
        volumeUI.text = volume.ToString();
    }
}