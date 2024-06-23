using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer gameSounds;
    public AudioMixer musicSounds;

    public void SetVolumeGame (float gameVolume)
    {
        gameSounds.SetFloat("gameVolume", gameVolume);
    }
    
    public void SetVolumeMusic (float musicVolume)
    {
        musicSounds.SetFloat("musicVolume", musicVolume);
    }

}
