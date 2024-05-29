using UnityEngine;

interface IInteractable {
    void Interact();
}

interface ITooltip {
    void InView();
}

public class Interactor : MonoBehaviour {
    [SerializeField, Range(1, 20)]
    float range;

    void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out RaycastHit rayHit, range)) {
            if(rayHit.collider.gameObject.TryGetComponent(out ITooltip tooltip)) {
                tooltip.InView();
            }

            if(Input.GetKeyDown(KeyCode.E)) {
                if(rayHit.collider.gameObject.TryGetComponent(out IInteractable interactable)) {
                    interactable.Interact();
                }
            }
        }
    }
}
