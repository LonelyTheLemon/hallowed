using UnityEngine;

public class Door : MonoBehaviour, IInteractable {
    bool open = false;
    bool unlocked = false;
    Vector3 rotation = Vector3.zero;
    float targetRotation = 0f;
    float turnSpeed = 100f;
    
    void Start() {
        Key.KeyCollectEvent += Unlock;
    }
    
    void Update() {
        // this animates the door
        if(open) {
            targetRotation = -95;
        } else {
            targetRotation = 0f;
        }
        rotation.y = Mathf.MoveTowards(rotation.y, targetRotation, turnSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(rotation);
    }
    
    // This function subscribes to KeyCollectEvent
    void Unlock() {
        unlocked = true;
    }

    public void Interact() {
        if(unlocked)
            open = !open;
    }
}
