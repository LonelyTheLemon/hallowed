using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSettings : MonoBehaviour {
    [SerializeField] Slider mouseSensitivitySlider;
    
    void Start() {
        mouseSensitivitySlider.value = SaveManager.playerSettings.mouseSensitivity;
        mouseSensitivitySlider.onValueChanged.AddListener(_ => UpdatePlayerSetting());
    }
    
    void UpdatePlayerSetting() {
        SaveManager.playerSettings.mouseSensitivity = mouseSensitivitySlider.value;
    }
}
