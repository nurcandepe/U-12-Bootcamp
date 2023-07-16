using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dungeonNewScene : MonoBehaviour
{
    public SOValues values;
    public string Scenename;
    public DungeonChestTrigger dect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dect.canExit)
            {
                //Debug.Log("READY");
                values.quest = 120;
                SceneManager.LoadScene(Scenename);
            }
        }
    }
}
