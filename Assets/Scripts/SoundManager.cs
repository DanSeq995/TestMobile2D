using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Riferimenti ai componenti AudioSources per la musica e gli SFX
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    // Metodo per attivare o disattivare la musica
    public void ToggleMusic(bool isMusicEnabled)
    {
        musicAudioSource.mute = !isMusicEnabled;
    }

    // Metodo per attivare o disattivare gli SFX
    public void ToggleSFX(bool isSFXEnabled)
    {
        sfxAudioSource.mute = !isSFXEnabled;
    }
}
