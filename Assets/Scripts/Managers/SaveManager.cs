using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string settingsFile;

    void Start()
    {
        settingsFile = Application.dataPath + "/config/settings.txt";
        LoadSettings();
    }

    /*void SaveSettings()
    {

    }*/

    void LoadSettings()
    {
        string content = File.ReadAllText(settingsFile).Trim();
        File.WriteAllText(Application.dataPath + "/config/test.txt", content);
    }
}
