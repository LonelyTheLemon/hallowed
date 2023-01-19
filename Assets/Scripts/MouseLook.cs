using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MouseLook : MonoBehaviour
{
    //mouse speed
    public float mouseSensitivity = 100f;
    public Transform playerBody;
 
    float xRotation = 0f;
 
    //locks the mouse on to the screen
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
 

    void Update()
    {
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


