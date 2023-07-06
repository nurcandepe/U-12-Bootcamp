using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Values", menuName = "Scriptable/Values")]
public class SOValues : ScriptableObject
{
    public string gender;
    public int quest;
    public int map;
    public int waypoint;
}
