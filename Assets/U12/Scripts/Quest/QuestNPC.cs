using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{

    public SOValues values;
    private int questNumber;
    private string questNPC;

    void Start()
    {
        questNPC = values.questNPCName;
        questNumber = values.quest;
    }

    void Update()
    {
        TrueNPCName();
    }

    void TrueNPCName()
    {
        questNumber = values.quest;
        switch (questNumber)
        {
            case 0:
                questNPC = "noneNPC";
                break;
            case 10:
                questNPC = "VillageElder";
                break;
            case 20:
                questNPC = "FarmerMartin";
                break;
            case 30:
                questNPC = "Priest";
                break;
            case 40:
                questNPC = "Priest";
                break;
            case 60:
                questNPC = "FarmerJustin";
                break;
            case 80:
                questNPC = "FarmerJustin";
                break;
            default:
                questNPC = "default";
                break;
        }
        values.questNPCName = questNPC;
    }
}
