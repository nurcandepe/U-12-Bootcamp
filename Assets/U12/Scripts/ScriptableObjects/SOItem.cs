using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOItem : ScriptableObject
{
    //Her itemda olmas� gereken temel �zellikleri
    public string itemName;
    public string itemDescription;
    public bool canStackable;
    public Sprite itemIcon; // UI'da g�z�kecek
    public GameObject itemPrefab;
}
