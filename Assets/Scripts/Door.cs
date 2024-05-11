using UnityEngine;

public class Door : MonoBehaviour, IInteractable {
    private bool open = false;
    public void Interact() {
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
