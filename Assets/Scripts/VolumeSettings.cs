using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer gameSounds;
    public AudioMixer musicSounds;

    public void SetVolumeGame (float gameVolume)
    {
        gameSounds.SetFloat("GameVolume", gameVolume);
    }
    
    public void SetVolumeMusic (float musicVolume)
    {
        musicSounds.SetFloat("musicVolume", musicVolume);
    }

}
