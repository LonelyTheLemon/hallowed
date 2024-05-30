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
    float range;

    public static event Action<GameObject> NewInteractableObject;
    GameObject hitObject = null;
    GameObject newHitObject = null;

    void Start() {
        // start the game as not perceiving any object
        NewInteractableObject?.Invoke(null);
    }

    void Update() {
        // normal ray cast
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out RaycastHit rayHit, range)) {
            newHitObject = rayHit.collider.gameObject;
        } else {
            newHitObject = null;
        }
        
        // invokes event when the perceived object changes
        if(newHitObject != hitObject) {
            NewInteractableObject?.Invoke(newHitObject);
        }
        
        // allows interacting with objects
        if(Input.GetKeyDown(KeyCode.E)) {
            if(newHitObject && newHitObject.TryGetComponent(out IInteractable interactable)) {
                interactable.Interact();
            }
        }
        
        // new hit object becomes old in the next frame
        hitObject = newHitObject;
    }
}
