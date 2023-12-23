using UnityEngine;

public class Button : MonoBehaviour, IInteractable {
    public void Interact() {
        Debug.Log("Button interacted!");
    }
}
