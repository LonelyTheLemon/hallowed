using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolTipPrompt : MonoBehaviour
{
    public GameObject toolTipPrompt;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Destroy(toolTipPrompt);
        }
    }
}