using UnityEngine;

interface IInteractable {
    void Interact();
}

public class Interactor : MonoBehaviour {
    [SerializeField, Range(1, 20)]
    float range;

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(ray, out RaycastHit rayHit, range)) {
                if(rayHit.collider.gameObject.TryGetComponent(out IInteractable obj)) {
                    obj.Interact();
                }
            }
        }
    }
}
