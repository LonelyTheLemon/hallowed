using UnityEngine;

public class GameManager : MonoBehaviour {
    
    void Start() {
        setLightNight();

        Bed.AfterSleepPhaseTrigger += setAfterSleepAmbience;
    }
    
    void setAfterSleepAmbience() {
        disableAmbientNight();
        setLightDay();
    }

    // TODO: Move into proper light manager
    Color nightColor = new Color(3 / 255, 3 / 255, 5 / 255, 1);
    Color dayColor = new Color(1, 1, 1, 1);
    [SerializeField] Transform[] lightObjects;

    void setLightNight() {
        foreach(Transform lightObject in lightObjects) {
            Light light = lightObject.gameObject.GetComponent<Light>();
            if(light != null) {
                light.color = nightColor;
            }
        }
    }

    void setLightDay() {
        foreach(Transform lightObject in lightObjects) {
            Light light = lightObject.gameObject.GetComponent<Light>();
            if(light != null) {
                light.color = dayColor;
            }
        }
    }
    
    [SerializeField] Transform[] sleepDisableSoundObjects;
    
    void disableAmbientNight() {
        foreach(Transform ambientObject in sleepDisableSoundObjects) {
            ambientObject.gameObject.SetActive(false);
        }
    }
}
