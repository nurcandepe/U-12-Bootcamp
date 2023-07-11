using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainQuest : MonoBehaviour
{
    public SOValues values;
    private GameObject questInfoPanel;
    private TextMeshProUGUI questInfoText;

    public int questNumber;
    public int deneme = 25;

    void Start()
    {
        questNumber = values.quest;
        questInfoPanel = GameObject.Find("QuestInfoPanel");
        questInfoText = GameObject.Find("QuestInfoText").GetComponent<TextMeshProUGUI>();

        questInfoText.text = "�lk G�revin";
        //Debug.Log(questInfoText.text);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeQuestInfo();
    }

    void ChangeQuestInfo()
    {
        questNumber = values.quest;
        switch (questNumber)
        {
            case 0:
                questInfoText.text = "G�rev Atanmad�";
                break;
            case 10:
                questInfoText.text = "�lk G�rev";
                break;
            default:
                questInfoText.text = "G�rev Yok";
                break;
        }
    }

    bool TrueNpc()
    {

        return false;
    }
}
