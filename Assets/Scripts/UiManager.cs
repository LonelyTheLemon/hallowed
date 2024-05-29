using UnityEngine;
using TMPro;

// [RequireComponent(typeof(Collider))]
public class UiManager : MonoBehaviour {
    TMP_Text tooltipUi;

    void Start() {
        tooltipUi = GameObject.Find("Tooltip").GetComponent<TMP_Text>();
        Tooltip.TooltipItemInView += UpdateTooltipMessage;
    }
    
    void Update() {
        if(!IsInvoking("TooltipItemInView")) {
            tooltipUi.text = "";
        }
    }
    
    public void UpdateTooltipMessage(string message) {
        tooltipUi.text = message;
    }
}