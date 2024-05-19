using UnityEngine;
using System;

public class Key : MonoBehaviour, IInteractable {
    public static event Action keyCollect;
    
    public void Interact() {
        keyCollect?.Invoke();
        Destroy(this.gameObject);
    }
}
