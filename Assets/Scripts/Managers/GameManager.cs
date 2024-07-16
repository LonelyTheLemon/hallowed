using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    // This section of GameManager acts as an event relay.
    // We technically don't need this middleman but it's
    // extremely useful for clarity and keeping track
    public static event Action AfterSleepPhaseSignal;
    
    void Start() {
        // Any function that subscribes to AfterSleepPhaseSignal will be triggered
        // if SleepPhaseTrigger is called from Bed
        Bed.AfterSleepPhaseTrigger += AfterSleepPhaseSignal;
    }
}
