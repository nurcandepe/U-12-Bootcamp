using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonChestTrigger : MonoBehaviour
{ 
    public bool canExit = false;
    private bool canUse = false;
    //public SOValues values;
    void Update()
    {
        if (canUse)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               canExit = true;
                Debug.Log("Can exit");
                //values.quest = 110;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Can rep");
        canUse = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Can NOT rep");
        canUse = false;
    }
}
