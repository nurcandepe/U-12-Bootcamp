using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    Inventory userInventory;
    MouseController mouseController;

    public GameObject inventoryPanel;
    //private bool isPanelOpen = false;


    //Paneldeki T�m Slotlar� G�steriyoruz
    public List<SlotUI> uiList = new List<SlotUI>();

    private void Start()
    {
        userInventory = gameObject.GetComponent<Inventory>();
        mouseController = gameObject.GetComponent<MouseController>();
        
        //Oyun ba��nda envanteri ve fare imlecini kapat�yoruz.
        inventoryPanel.SetActive(false);
        mouseController.MouseOff();
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PanelAutoReverse();
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i<uiList.Count; i++)
        {
            if(userInventory.playerInventory.inventorySlots[i].itemCount > 0)
            {
                uiList[i].itemImage.sprite = userInventory.playerInventory.inventorySlots[i].item.itemIcon;
                if (userInventory.playerInventory.inventorySlots[i].item.canStackable == true)
                {
                    uiList[i].itemCountText.gameObject.SetActive(true);
                    uiList[i].itemCountText.text = userInventory.playerInventory.inventorySlots[i].itemCount.ToString();
                }
                else
                {
                    uiList[i].itemCountText.gameObject.SetActive(false);
                }
            }
            else
            {
                uiList[i].itemImage.sprite = null;
                uiList[i].itemCountText.gameObject.SetActive(false);
            }
        }
    }

    private void PanelAutoReverse()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
            mouseController.MouseOff();
        }
        else
        {
            inventoryPanel.SetActive(true);
            mouseController.MouseOn();
        }
    }
}
