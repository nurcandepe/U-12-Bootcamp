using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basenewscene : MonoBehaviour
{

    public string Scenename;

    GoldenPaddle paddle2;
    void OnTriggerEnter(Collider other)
    {
        paddle2 = FindObjectOfType<GoldenPaddle>();
        if (other.CompareTag("Player") && paddle2.isKeyPicked)
        {
            SceneManager.LoadScene(Scenename);
        }
    }
}
