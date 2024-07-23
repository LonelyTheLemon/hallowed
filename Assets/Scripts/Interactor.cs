using UnityEngine;
using System;

interface IInteractable {
    void Interact();
}

interface ITooltip {
    string Tooltip { get; }
}

public class Interactor : MonoBehaviour {
    [SerializeField, Range(1, 20)]
    float rayDistance = 5;
    [SerializeField]
    LayerMask rayIgnoreMask;

    public static event Action<GameObject> NewInteractableObject;
    GameObject hitObject = null;

    void Start() {
        // start the game as not perceiving any object
        NewInteractableObject?.Invoke(null);
    }

    void Update() {
        // normal ray cast
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out RaycastHit rayHit, rayDistance, ~rayIgnoreMask)) {
            hitObject = rayHit.collider.gameObject;
        } else {
            hitObject = null;
        }
        
        // allows interacting with objects
        if(Input.GetKeyDown(KeyCode.E)) {
            if(hitObject && hitObject.TryGetComponent(out IInteractable interactable)) {
                interactable.Interact();
            }
        }
        
        // invokes on perceived object
        NewInteractableObject?.Invoke(hitObject);
    }
}
