using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOItem : ScriptableObject
{
    //Her itemda olmasý gereken temel özellikleri
    public string itemName;
    public string itemDescription;
    public bool canStackable;
    public Sprite itemIcon; // UI'da gözükecek
    public GameObject itemPrefab;
}
