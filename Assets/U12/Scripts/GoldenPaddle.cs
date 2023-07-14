using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenPaddle : MonoBehaviour
{
    public bool didPaddle = false; // Teleport Scriptinde Kullanilacak
    private bool canPick = false;
    [SerializeField] GameObject paddle;

    private void OnTriggerEnter(Collider other)
    {
        canPick = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canPick = false;
    }

    void Update()
    {
        if (canPick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                didPaddle = true;
                canPick = false;
                Destroy(paddle);
            }
        }
    }
}
