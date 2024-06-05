using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource On_Off;

    bool on;
    bool off;


    void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(off && Input.GetKeyDown(KeyCode.F)){
            flashlight.SetActive(true);
            On_Off.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetKeyDown(KeyCode.F)){
            flashlight.SetActive(false);
            On_Off.Play();
            off = true;
            on = false;
        }
    }
}
