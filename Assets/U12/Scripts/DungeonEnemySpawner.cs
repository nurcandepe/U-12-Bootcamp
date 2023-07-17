using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemies;
    private bool count = false;
    void OnTriggerEnter(Collider other)
    {
        if (count == false)
        {
            Instantiate(enemies);
            count = true;
        }
    }
}
