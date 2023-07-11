using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue : MonoBehaviour
{
    private MainQuest mainQuest;

    void Start()
    {
        mainQuest = GetComponent<MainQuest>();
        Debug.Log(mainQuest.questNumber);
    }

    void Update()
    {
        
    }

    void ChangeQuestDialogue()
    {

    }
}
