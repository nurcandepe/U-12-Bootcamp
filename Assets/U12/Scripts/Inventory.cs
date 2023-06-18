using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SOInventory playerInventory;
    InventoryUIController inventoryUI;

    private void Start()
    {
        inventoryUI = gameObject.GetComponent<InventoryUIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventoryUI.UpdateUI();
            }
        }
    }
}
