using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuSettings : MonoBehaviour {
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider gameVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider mouseSensitivitySlider;
    
    void Start() {
        gameVolumeSlider.value = SaveManager.playerSettings.gameVolume;
        musicVolumeSlider.value = SaveManager.playerSettings.musicVolume;
        mouseSensitivitySlider.value = SaveManager.playerSettings.mouseSensitivity;
        gameVolumeSlider.onValueChanged.AddListener(_ => UpdateGameVolume());
        musicVolumeSlider.onValueChanged.AddListener(_ => UpdateMusicVolume());
        mouseSensitivitySlider.onValueChanged.AddListener(_ => UpdateMouseSensitivity());
    }
    
    void UpdateGameVolume() {
        audioMixer.SetFloat("Game", gameVolumeSlider.value);
        SaveManager.playerSettings.gameVolume = gameVolumeSlider.value;
    }
    
    void UpdateMusicVolume() {
        audioMixer.SetFloat("Music", musicVolumeSlider.value);
        SaveManager.playerSettings.musicVolume = musicVolumeSlider.value;
    }

    void UpdateMouseSensitivity() {
        SaveManager.playerSettings.mouseSensitivity = mouseSensitivitySlider.value;
    }
}
