using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> playlist;
    public AudioMixerGroup mixerGroup;
    private AudioSource audioSource;
    private int currentIndex = -1;

    private static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixerGroup;

        audioSource.loop = false;
        audioSource.playOnAwake = false;

        PlayRandomSong();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomSong();
        }
    }

    private void PlayRandomSong()
    {
        if (playlist.Count == 0)
        {
            Debug.LogWarning("Playlist is empty.");
            return;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, playlist.Count);
        } while (randomIndex == currentIndex);

        currentIndex = randomIndex;
        audioSource.clip = playlist[currentIndex];
        audioSource.Play();
    }
}
