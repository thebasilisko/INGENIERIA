using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public FlashLight luzLinterna;
    public bool activeLight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            activeLight = !activeLight;

            if(activeLight == true)
            {
                luzLinterna.enabled = true;
            }

            if (activeLight == false)
            {
                luzLinterna.enabled = false;
            }
        }
    }
}
