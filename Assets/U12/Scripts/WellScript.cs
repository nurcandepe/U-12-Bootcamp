using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellScript : MonoBehaviour
{
    [SerializeField] GameObject wellPoint;
    [SerializeField] GameObject brokenWell;
    [SerializeField] GameObject repairedWell;
    GameObject oldWell;
    GameObject newWell;
    private bool canRepair;
    private bool repairCount;
    public SOValues values;

    private Inventory inventory;

    void Start()
    {
        oldWell = Instantiate(brokenWell, wellPoint.transform);
        canRepair = false;
        repairCount = true;

        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if(inventory.GetItemCount("Stone6") >= 3)
        {
            if (canRepair)
            {
                if (repairCount)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //Debug.Log("HAVE ENOUGH");
                        Destroy(oldWell);
                        newWell = Instantiate(repairedWell, wellPoint.transform);
                        inventory.DeleteItemCount("Stone6", 3);
                        values.quest = 80;
                        repairCount = false;
                    }
                }
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Can rep");
        canRepair = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Can NOT rep");
        canRepair = false;
    }
}
