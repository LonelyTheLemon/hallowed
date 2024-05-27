using UnityEngine;

public class Door : MonoBehaviour, IInteractable {
    private bool open = false;
    private bool unlocked = false;
    
    private void Start() {
        Key.KeyCollectEvent += Unlock;
    }
    
    public void Unlock() {
        unlocked = true;
    }

    public void Interact() {
        // is locked until player picks up key
        if(!unlocked)
            return;
        Vector3 rotation = Vector3.zero;
        if(open) {
            rotation.y = 0;
        } else {
            rotation.y = -90;
        }
        transform.localRotation = Quaternion.Euler(rotation);
        open = !open;
    }
}
