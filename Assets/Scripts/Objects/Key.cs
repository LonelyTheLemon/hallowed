using UnityEngine;
using System;

public class Key : MonoBehaviour, IInteractable, ITooltip {
    [SerializeField] string tooltip = "Key";
    public string Tooltip => tooltip;
    public static event Action KeyCollectEvent;
    public AudioSource Grabbed;
    
    public void Interact() {
        KeyCollectEvent?.Invoke();
        Grabbed.Play();
        gameObject.SetActive(false);
    }
}
