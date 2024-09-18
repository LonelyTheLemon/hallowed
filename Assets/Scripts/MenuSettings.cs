using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuSettings : MonoBehaviour {
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider gameVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider mouseSensitivitySlider;
    
    void Start() {
        // make sliders consistent, then update once, then hook up update
        gameVolumeSlider.value = SaveManager.playerSettings.gameVolume;
        musicVolumeSlider.value = SaveManager.playerSettings.musicVolume;
        mouseSensitivitySlider.value = SaveManager.playerSettings.mouseSensitivity;
        UpdateGameVolume();
        UpdateMusicVolume();
        UpdateMouseSensitivity();
        gameVolumeSlider.onValueChanged.AddListener(_ => UpdateGameVolume());
        musicVolumeSlider.onValueChanged.AddListener(_ => UpdateMusicVolume());
        mouseSensitivitySlider.onValueChanged.AddListener(_ => UpdateMouseSensitivity());
    }
    
    void UpdateGameVolume() {
        audioMixer.SetFloat("Game", Mathf.Log10(gameVolumeSlider.value) * 20f);
        SaveManager.playerSettings.gameVolume = gameVolumeSlider.value;
    }
    
    void UpdateMusicVolume() {
        audioMixer.SetFloat("Music", Mathf.Log10(musicVolumeSlider.value) * 20f);
        SaveManager.playerSettings.musicVolume = musicVolumeSlider.value;
    }

    void UpdateMouseSensitivity() {
        SaveManager.playerSettings.mouseSensitivity = mouseSensitivitySlider.value;
    }
}
