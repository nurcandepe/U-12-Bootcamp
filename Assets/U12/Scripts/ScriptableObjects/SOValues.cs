using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Values", menuName = "Scriptable/Values")]
public class SOValues : ScriptableObject
{
    public string gender;
    public string playerName;
    public int quest;
    public string questNPCName;
    public string triggerNPC;
    public int map;
    public int waypoint;
}
