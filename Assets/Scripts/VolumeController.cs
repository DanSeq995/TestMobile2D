using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public TextMeshProUGUI volumeUI;
    private int volume;

    private void Start()
    {
        volume = 0;
        SetVolume(volume);
    }

    public void VolumeUp()
    {
        print(volume);
        volume = volume + 1;
        SetVolume(volume);
    }

    public void VolumeDown()
    {
        print(volume);
        volume = volume - 1;
        SetVolume(volume);        
    }

    private void SetVolume(int volume)
    {
        volumeUI.text = volume.ToString();
    }
}
