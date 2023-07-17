using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class midwinterNewScene : MonoBehaviour
{
    public SOValues values;
    public string Scenename;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            values.quest = 140;
            SceneManager.LoadScene(Scenename);
        }
    }
}
