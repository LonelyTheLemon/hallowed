using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class SaveManager : MonoBehaviour {
    // TODO: Remove this slop. Make UI enabled on start so we don't have to
    // put stuff like this here.
    [SerializeField] AudioMixer audioMixer;

    IDataService dataService = new JsonDataService();
    const string RelativeSettingsPath = "player-settings.json";
    public static PlayerSettings playerSettings = new PlayerSettings();
    
    // load settings from disk
    void Start() {
        playerSettings = LoadSettings();
        audioMixer.SetFloat("Game", playerSettings.gameVolume);
        audioMixer.SetFloat("Music", playerSettings.musicVolume);
        // mouse sensitivity is used by MouseLook so it is not set to anything
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
