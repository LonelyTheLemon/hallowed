using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    // This section of GameManager acts as an event relay.
    // We technically don't need this middleman but it's
    // extremely useful for clarity and keeping track
    public static event Action AfterSleepPhaseSignal;
    
    void Start() {
        setLightNight();

        // Any function that subscribes to AfterSleepPhaseSignal will be triggered
        // if SleepPhaseTrigger is called from Bed
        Bed.AfterSleepPhaseTrigger += AfterSleepPhaseSignal;
        Bed.AfterSleepPhaseTrigger += setLightDay;
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
}
