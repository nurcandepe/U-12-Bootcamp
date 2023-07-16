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

    public int GetItemCount(string objectName)
    {
        int count = 0;

        foreach (Slot slot in playerInventory.inventorySlots)
        {
            if (slot.item != null && slot.item.itemName == objectName)
            {
                count += slot.itemCount;
            }
        }
        return count;
    }

    public void DeleteItemCount(string objectName, int amount)
    {
        int remainingAmount = amount;

        foreach (Slot slot in playerInventory.inventorySlots)
        {
            if (slot.item != null && slot.item.itemName == objectName)
            {
                if (slot.itemCount <= remainingAmount)
                {
                    remainingAmount -= slot.itemCount;
                    slot.itemCount = 0;
                    slot.item = null;
                    slot.isFull = false;
                }
                else
                {
                    slot.itemCount -= remainingAmount;
                    remainingAmount = 0;
                    break;
                }
            }
        }
        inventoryUI.UpdateUI();
    }
}
