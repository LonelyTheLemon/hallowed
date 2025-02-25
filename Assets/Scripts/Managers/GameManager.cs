using UnityEngine;

public class GameManager : MonoBehaviour {
    
    void Start() {
        setLightNight();

        Bed.AfterSleepPhaseTrigger += setAfterSleepAmbience;
    }
    
    void setAfterSleepAmbience() {
        disableAmbientNight();
        enableAmbientDay();
        setLightDay();
        disableParticleNight();
    }

    // TODO: Move into proper light manager
    Color nightColor = new Color(3 / 255f, 3 / 255f, 5 / 255f, 1);
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
    [SerializeField] Transform[] sleepEnableSoundObjects;
    [SerializeField] Transform[] sleepDisableParticleObjects;
    
    void disableAmbientNight() {
        foreach(Transform ambientObject in sleepDisableSoundObjects) {
            ambientObject.gameObject.SetActive(false);
        }
    }
    
    void enableAmbientDay() {
        foreach(Transform ambientObject in sleepEnableSoundObjects) {
            ambientObject.gameObject.SetActive(true);
        }
    }


    void disableParticleNight() {
        foreach (Transform ambientObject in sleepDisableParticleObjects) {
            ambientObject.gameObject.SetActive(false);
        }
    }
}