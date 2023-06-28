using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private CharacterController characterController;
    private bool isMouseLocked = true;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MouseAutoReverse()
    {
        if (isMouseLocked)
        {
            MouseOn();
        }
        else
        {
            MouseOff();
        }
    }

    public void MouseOn()
    {
        //characterController.enabled = true;
        isMouseLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MouseOff()
    {
        //characterController.enabled = false;
        isMouseLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
