using UnityEngine;
using System;

public class Bed : MonoBehaviour, IInteractable, ITooltip {
    [SerializeField] string tooltip = "Bed";
    public string Tooltip => tooltip;
    public static event Action AfterSleepPhaseTrigger;
    bool hasSlept = false;
    
    public void Interact() {
        if (!hasSlept) {
            AfterSleepPhaseTrigger?.Invoke();
            hasSlept = true;
        }
    }
}
