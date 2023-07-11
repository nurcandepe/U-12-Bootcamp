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

        questInfoText.text = "Ýlk Görevin";
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
                questInfoText.text = "Görev Atanmadý";
                break;
            case 10:
                questInfoText.text = "Ýlk Görev";
                break;
            default:
                questInfoText.text = "Görev Yok";
                break;
        }
    }

    bool TrueNpc()
    {

        return false;
    }
}
