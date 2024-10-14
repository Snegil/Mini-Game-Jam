using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ToggleCursorLock();
        ToggleCursorVisibility();
    }

    public void ToggleCursorLock() 
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ToggleCursorVisibility()
    {
        if ( Cursor.visible == false)
        {
            Cursor.visible = true;
            return;
        }
        Cursor.visible = false;
    }
}
