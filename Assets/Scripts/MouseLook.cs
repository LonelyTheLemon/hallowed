using UnityEngine;
 
public class MouseLook : MonoBehaviour
{
    //mouse speed
    public float mouseSensitivity = 100f;
    public Transform playerBody;
 
    float xRotation = 0f;
    
    KeyCode pauseKey = KeyCode.None;
 
    void Start() {
        // in unity editor you can hit escape in play mode to unfocus the mouse.
        // this is undesirable behavior that can't be turned off, hence this workaround.
        #if UNITY_EDITOR
        pauseKey = KeyCode.BackQuote; // backquote is under escape key
        #else
        pauseKey = KeyCode.Escape; // normal escape in build
        #endif

        Cursor.lockState = CursorLockMode.Locked;
    }
 

    void Update()
    {
        if(Input.GetKeyDown(pauseKey)) {
            switch(Cursor.lockState) {
                case CursorLockMode.Locked:
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case CursorLockMode.None:
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
            }
        }
        
        if(Cursor.lockState == CursorLockMode.Locked) {
            //gets where the mouse is on the screen
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
     
            //moves the mouse onto the x and y plan and locks the y plane at 90 up and 90 down
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
     
            //player body rotation when moving mouse
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}


