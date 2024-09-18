using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField] Transform playerBody;

    float xRotation = 0f;
    bool isScriptEnabled = true;

    //changeable cursor lock state
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        //Escape enables and disables the mouse look script
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleScriptEnabledState();
        }
        //mouse x and y axis movement
        if (isScriptEnabled) {
            float mouseX = Input.GetAxis("Mouse X") * SaveManager.playerSettings.mouseSensitivity * Time.deltaTime * 20;
            float mouseY = Input.GetAxis("Mouse Y") * SaveManager.playerSettings.mouseSensitivity * Time.deltaTime * 20;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    //manages lock states and script enabling 
    void ToggleScriptEnabledState() {
        isScriptEnabled = !isScriptEnabled;

        if (isScriptEnabled) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}