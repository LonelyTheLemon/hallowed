using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioZoneController : MonoBehaviour
{
    public float fadeDuration = 1f; // fade in/out time (in seconds)
    float quietVolume = 0.1f; 
    float normalVolume = 1f;  
    
    public List<AudioSource> ignoredSounds; // List of AudioSources that should not be affected
    public List<AudioSource> allGameSounds; // List of all AudioSources in the game

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Fade out all game sounds except ignored sounds
            foreach (AudioSource source in allGameSounds)
            {
                if (!ignoredSounds.Contains(source))
                {
                    StartCoroutine(FadeOutSource(source, fadeDuration, quietVolume));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Fade in all game sounds except ignored sounds
            foreach (AudioSource source in allGameSounds)
            {
                if (!ignoredSounds.Contains(source))
                {
                    StartCoroutine(FadeInSource(source, fadeDuration, normalVolume));
                }
            }
        }
    }

    // gradually fade out the volume of a specific AudioSource
    private IEnumerator FadeOutSource(AudioSource source, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = source.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        source.volume = targetVolume;
    }

    // gradually fade in the volume of a specific AudioSource
    private IEnumerator FadeInSource(AudioSource source, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = source.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        source.volume = targetVolume;
    }
}
