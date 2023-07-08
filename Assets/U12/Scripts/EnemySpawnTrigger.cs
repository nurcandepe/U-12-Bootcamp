using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    [SerializeField] GameObject enemy5;

    void Start()
    {
        if (enemy1 != null)
        {
            enemy1.SetActive(false);
        }

        if (enemy1 != null)
        {
            enemy2.SetActive(false);
        }

        if (enemy1 != null)
        {
            enemy3.SetActive(false);
        }

        if (enemy1 != null)
        {
            enemy4.SetActive(false);
        }

        if (enemy1 != null)
        {
            enemy5.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemy1 != null)
        {
            enemy1.SetActive(true);
        }

        if (enemy1 != null)
        {
            enemy2.SetActive(true);
        }

        if (enemy1 != null)
        {
            enemy3.SetActive(true);
        }

        if (enemy1 != null)
        {
            enemy4.SetActive(true);
        }

        if (enemy1 != null)
        {
            enemy5.SetActive(true);
        }

    }

}
