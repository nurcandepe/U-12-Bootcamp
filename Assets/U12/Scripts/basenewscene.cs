using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basenewscene : MonoBehaviour
{
    public SOValues values;
    public string Scenename;

    GoldenPaddle paddle2;
    void OnTriggerEnter(Collider other)
    {
        paddle2 = FindObjectOfType<GoldenPaddle>();
        if (other.CompareTag("Player") && paddle2.isKeyPicked)
        {
            values.quest = 60;
            SceneManager.LoadScene(Scenename);
        }
    }
}
