using System;
using UnityEngine;

public class Tooltip : MonoBehaviour, ITooltip {
    [SerializeField] string tooltip = "";
    public static event Action<string> TooltipItemInView;
    
    public void InView() {
        TooltipItemInView?.Invoke(tooltip);
    }
}