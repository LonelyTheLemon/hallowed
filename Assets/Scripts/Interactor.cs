using UnityEngine;

interface IInteractable {
    void Interact();
}

public class Interactor : MonoBehaviour {
    [SerializeField]
    Transform InteractorSource;
    [SerializeField, Range(1, 20)]
    float InteractRange;

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange)) {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable obj)) {
                    obj.Interact();
                }
            }
        }
    }
}
