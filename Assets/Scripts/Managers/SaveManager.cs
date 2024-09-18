using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    IDataService dataService = new JsonDataService();
    const string RelativeSettingsPath = "player-settings.json";
    public static PlayerSettings playerSettings = new PlayerSettings();
    
    // load settings from disk
    void Start() {
        playerSettings = LoadSettings();
    }
    
    // saves settings when changing scenes or quitting
    void OnDestroy() {
        SaveSettings();
    }

    void SaveSettings() {
        dataService.SaveData(RelativeSettingsPath, playerSettings);
        // Debug.Log($"SAVE: {playerSettings.mouseSensitivity}");
    }
    
    PlayerSettings LoadSettings() {
        PlayerSettings s = new PlayerSettings();
        // safeguard for first run
        if(File.Exists(Path.Combine(Application.persistentDataPath, RelativeSettingsPath))) {
            s = dataService.LoadData<PlayerSettings>(RelativeSettingsPath);
            // Debug.Log($"LOAD: {s.mouseSensitivity}");
        }
        else {
            // Debug.Log("LOAD: Data doesn't exist!");
        }
        
        return s;
    }
}
