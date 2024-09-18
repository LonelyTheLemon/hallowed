using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    IDataService dataService = new JsonDataService();
    const string RelativeSettingsPath = "player-settings.json";
    public static PlayerSettings playerSettings = new PlayerSettings();
    
    // load settings before other scripts use it in Start
    void Awake() {
        playerSettings = LoadSettings();
    }
    
    // saves settings when changing scenes or quitting
    void OnDestroy() {
        SaveSettings();
    }

    void SaveSettings() {
        dataService.SaveData(RelativeSettingsPath, playerSettings);
    }
    
    PlayerSettings LoadSettings() {
        // safeguard for first run
        PlayerSettings s = new PlayerSettings();
        if(File.Exists(Path.Combine(Application.persistentDataPath, RelativeSettingsPath))) {
            s = dataService.LoadData<PlayerSettings>(RelativeSettingsPath);
        }
        
        return s;
    }
}
