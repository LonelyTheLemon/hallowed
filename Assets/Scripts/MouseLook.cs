using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    //mouse sensitivity function 
    private float mouseSensitivity = 50f;
    public Transform playerBody;

    private float xRotation = 0f;
    private bool isScriptEnabled = true;

    //used to control mouse sens in game using a slider
    public Slider Sensitivity;

    //changeable cursor lock state
    private void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("current Sensitivity", 50);
        Sensitivity.value = mouseSensitivity / 20;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Escape enables and disables the mouse look script
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleScriptEnabledState();
        }
        //mouse x and y axis movement
        if (isScriptEnabled)
        {
            PlayerPrefs.SetFloat("Current Sensitivity", mouseSensitivity);
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 20;
    }

    //manages lock states and script enabling 
    private void ToggleScriptEnabledState()
    {
        isScriptEnabled = !isScriptEnabled;

        if (isScriptEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}