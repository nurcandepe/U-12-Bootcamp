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
            case 30:
                questInfoText.text = "CASE 30 \n5 kütük topla ve papaza götür";
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
                dialogueNameText.text = values.triggerNPC;
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
            case 20:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Hello, Mr. Martin. The village elder mentioned you might have some tasks for me.";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        dialogueNameText.text = "Farmer Martin";
                        dialogueText.text = "I do indeed. But before you venture into the forest, there's something you need to know. Beware of the dangers that lurk within. You may encounter fierce and wild beasts while chopping down the trees.";
                        dialogueNumber = 20;
                        break;
                    case 20:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Thank you for the warning, Mr. Martin. I'll equip myself accordingly and proceed with caution. Once I have the logs, where should I take them?";
                        dialogueNumber = 30;
                        break;
                    case 30:
                        dialogueNameText.text = "Farmer Martin";
                        dialogueText.text = "Once you have the five logs, take them to the village church and seek the guidance of the wise old priest. He holds the knowledge to guide you further on your quest.";
                        dialogueNumber = 40;
                        break;
                    case 40:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Understood, Mr. Martin. I won't underestimate the forest's dangers, and I'll stay vigilant. Thank you for your advice.";
                        dialogueNumber = 50;
                        break;
                    case 50:
                        values.quest = 30;
                        DeactiveDialogue();
                        break;
                }
                break;
            case 30:
                //Ýf içerisine bu görev için 5 kütük getirip getirilmediði kontrol edilecek
                if (true)
                {
                    switch (dialogueNumber)
                    {
                        case 0:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "Greetings, wise priest. I have come bearing the logs as a donation to the village church, as instructed by Mr. Martin. I've completed the task given by Mr. Martin to reach the treasure. What is the next step, wise priest?";
                            dialogueNumber = 10;
                            break;
                        case 10:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Ah, young warrior, your spirit and determination shine bright. At the summit of the treacherous mountain lies a hidden treasure—a sacred oar. It is said to possess remarkable powers. Retrieve this oar, for it will be a key to unveiling the secrets you seek.";
                            dialogueNumber = 20;
                            break;
                        case 20:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "A sacred oar? I had no knowledge of it. How can I reach it, wise priest?";
                            dialogueNumber = 30;
                            break;
                        case 30:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Journey to the mountain's peak, young warrior, and search for the sacred oar. Be wary of the dangers that await you, for fierce creatures guard the way. Trust your instincts and return safely with the oar.";
                            dialogueNumber = 40;
                            break;
                        case 40:
                            dialogueNameText.text = activeName;
                            dialogueText.text = " I accept this challenge, wise priest. With your blessings and guidance, I will ascend the mountain and take the sacred oar.";
                            dialogueNumber = 50;
                            break;
                        case 50:
                            values.quest = 40;
                            DeactiveDialogue();
                            break;
                    }
                }
                else
                {
                    switch (dialogueNumber)
                    {
                        case 0:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Önce kütükleri görelim....";
                            dialogueNumber = 10;
                            break;
                        case 10:
                            DeactiveDialogue();
                            break;
                    }
                }
                break;
            default:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = values.triggerNPC;
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
