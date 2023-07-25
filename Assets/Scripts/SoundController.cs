using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.AudioManager;
using TMPro;


public class SoundController : MonoBehaviour
{
    public AudioManager audioManager;
    public MusicPlayer musicPlayer;
    public TextMeshProUGUI musicUI;
    public TextMeshProUGUI sfxUI;


    private float trackPosition;
    private AudioClip currentTrack;
    private bool isMusicOn = true; 
    private bool isSFXOn = true;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer.PlayTrack();
        currentTrack = musicPlayer.GetActiveTrack;
    }

    // Update is called once per frame
    void Update()
    {
        setTextMusic();
        setTextSFX();
    }

        public void ToggleMusic()
    {
        if(isMusicOn){
            musicPlayer.SetVolume(0.0f);
            isMusicOn = false;
        }else{
            musicPlayer.SetVolume(1.0f);
            isMusicOn = true;
        };
    }

    public void ToggleSFX()
    {
        if(isSFXOn){
            audioManager.CanPlayAudio=false;
            isSFXOn = false;
        }else{
            audioManager.CanPlayAudio=true;
            isSFXOn = true;
        };
    }

    void setTextSFX(){
           if(isSFXOn){
            sfxUI.SetText("SFX\nON");
        }else{
            sfxUI.SetText("SFX\nOFF");
        }
    }

    void setTextMusic(){
           if(isMusicOn){
            musicUI.SetText("Music\nON");
        }else{
            musicUI.SetText("Music\nOFF");
        }
    }

    public void playSwipe(){
        audioManager.Play("click_01");
    }
}
