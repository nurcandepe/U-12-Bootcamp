using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Agac");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Agac cikti");
    }
}
