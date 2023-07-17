using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class desert2NewScene : MonoBehaviour
{
    public SOValues values;
    public string Scenename;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                values.quest = 130;
                SceneManager.LoadScene(Scenename);
        }
    }
}
