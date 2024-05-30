using UnityEngine;
using TMPro;

// [RequireComponent(typeof(Collider))]
public class UiManager : MonoBehaviour {
    TMP_Text tooltipUi;

    void OnEnable() {
        Interactor.NewInteractableObject += UpdateTooltipText;
    }
    
    void Awake() {
        tooltipUi = GameObject.Find("Tooltip").GetComponent<TMP_Text>();
    }
    
    public void UpdateTooltipText(GameObject obj) {
        if(obj && obj.TryGetComponent(out ITooltip tooltip)) {
            tooltipUi.text = tooltip.Tooltip;
        } else {
            tooltipUi.text = "";
        }
    }
}