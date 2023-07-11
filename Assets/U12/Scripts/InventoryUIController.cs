using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    Inventory userInventory;
    MouseController mouseController;

    //Sahnedeki inventory paneli ve slotlarý ekliyoruz
    private GameObject inventoryPanel;
    private List<SlotUI> uiList;

    private void Start()
    {
        inventoryPanel = GameObject.Find("InventoryPanel");
        uiList = new List<SlotUI>(GameObject.FindGameObjectsWithTag("InventoryButton").Select(go => go.GetComponent<SlotUI>()));
        uiList.Reverse(); //Elemanlar ters sýralanýyor düzeltmek için

        userInventory = gameObject.GetComponent<Inventory>();
        mouseController = gameObject.GetComponent<MouseController>();
        
        //Oyun baþýnda envanteri ve fare imlecini kapatýyoruz.
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
