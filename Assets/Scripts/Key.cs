using UnityEngine;
using System;

public class Key : MonoBehaviour, IInteractable {
    public static event Action KeyCollectEvent;
    
    public void Interact() {
        KeyCollectEvent?.Invoke();
        Destroy(this.gameObject);
    }
}
