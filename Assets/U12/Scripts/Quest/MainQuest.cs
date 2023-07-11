using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class MainQuest : MonoBehaviour
{
    public SOValues values;

    //Saðdaki görev takip paneli
    private GameObject questInfoPanel;
    private TextMeshProUGUI questInfoText;

    //diyalog paneli
    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueNameText;
    private TextMeshProUGUI dialogueText;

    private int dialogueNumber;
    public int questNumber;
    public string questNPC;

    private ThirdPersonController tpController;
    private Animator animator;

    private string activeName = "Victor";

    void Start()
    {
        questNumber = values.quest;

        //Saðdaki görev takip paneli
        questInfoPanel = GameObject.Find("QuestInfoPanel");
        questInfoText = GameObject.Find("QuestInfoText").GetComponent<TextMeshProUGUI>();

        //diyalog paneli
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialogueNameText = GameObject.Find("DialogueNameText").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        //baþlangýþta diyalog panelini kapatýyoruz ve sýfýrlýyoruz
        dialoguePanel.SetActive(false);
        dialogueNumber = 0;

        questInfoText.text = "Ýlk Görevin";

        tpController = GetComponentInParent<ThirdPersonController>();
        animator = GetComponentInParent<Animator>();

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
                questInfoText.text = "CASE 10 \nKöylü ile konuþ";
                break;
            case 20:
                questInfoText.text = "CASE 20 \nÇiftçi ile konuþ";
                break;
            default:
                questInfoText.text = "Görev Yok";
                break;
        }
    }

    void WrongDialogue()
    {
        tpController.enabled = false;
        animator.SetBool("npcTalk", true);

        questNumber = values.quest;

        switch (dialogueNumber)
        {
            case 0:
                dialogueText.text = "Bugünlerde hava bir garip...";
                dialogueNumber = 10;
                break;
            case 10:
                DeactiveDialogue();
                break;
        }
    }

    void ChangeDialogue()
    {
        tpController.enabled = false;
        animator.SetBool("npcTalk", true);

        questNumber = values.quest;
        switch (questNumber)
        {
            case 10:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = "Village Elder";
                        dialogueText.text = "I heard you're finally turning 18 today. Congratulations, kid! It means you can embark on the sea journey to distant islands now.";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Thank you, sir! I've been eagerly waiting for this day. I heard there's a rumor about a treasure hidden on one of the islands. I want to find it and prove myself as a worthy warrior.";
                        dialogueNumber = 20;
                        break;
                    case 20:
                        dialogueNameText.text = "Village Elder";
                        dialogueText.text = "Ah, the treasure! It's been a talk of the town lately. They say it's hidden deep within the islands, waiting for someone brave enough to claim it. If you're serious about this quest, you must start by following the signs and completing various tasks.";
                        dialogueNumber = 30;
                        break;
                    case 30:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "I'm ready for the challenge! Who should I seek first to begin my journey?";
                        dialogueNumber = 40;
                        break;
                    case 40:
                        dialogueNameText.text = "Village Elder";
                        dialogueText.text = "Head over to the farmer's fields, kid. Martin knows these lands like the back of his hand. Help him with his chores, and he might have valuable information or tasks for you.";
                        dialogueNumber = 50;
                        break;
                    case 50:
                        values.quest = 20;
                        DeactiveDialogue();
                        break;
                }
                break;
            default:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueText.text = "Bugünlerde hava bir garip...";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        DeactiveDialogue();
                        break;
                }
                break;
        }
    }

    public void ActiveDialogue()
    {
        if (TrueNpc())
        {
            dialoguePanel.SetActive(true);
            ChangeDialogue();
        }
        else
        {
            dialoguePanel.SetActive(true);
            WrongDialogue();
        }
    }

    //Doðru npc ile konuþup konuþmadýðýmýzý döndürüyor
    bool TrueNpc()
    {
        if (values.questNPCName == values.triggerNPC)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DeactiveDialogue()
    {
        dialogueNumber = 0;
        dialoguePanel.SetActive(false);
        tpController.enabled = true;
        animator.SetBool("npcTalk", false);
    }
}
