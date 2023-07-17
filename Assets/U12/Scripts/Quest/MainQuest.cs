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

    private Inventory inventory; //Item kontrolu icin Inventory scriptine erisim
    private GoldenPaddle paddle;

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

        questInfoText.text = "Your First Mission";

        tpController = GetComponentInParent<ThirdPersonController>();
        animator = GetComponentInParent<Animator>();

        inventory = FindObjectOfType<Inventory>();
        paddle = FindObjectOfType<GoldenPaddle>();

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
                questInfoText.text = "Mission not assigned";
                break;
            case 10:
                questInfoText.text = "MISSION 1 \n\nTalk with the village elder.";
                break;
            case 20:
                questInfoText.text = "MISSION 2 \n\nFollow the path. Head over to the Farmer Martin’s fields. Help him with his chores.";
                break;
            case 30:
                questInfoText.text = "MISSION 3 \n\nChop down the trees in the logging area. Once you have the 5 logs, take them to the Priest. Follow the path.";
                break;
            case 40:
                questInfoText.text = "MISSION 4 \n\nGo to the summit of the mountain and take the Sacred Oar, then talk with Priest";
                break;
            case 50:
                questInfoText.text = "MISSION 5 \n\nReach the pier and board the boat to the next island. Follow the path you used before.";
                break;
            case 60:
                questInfoText.text = "MISSION 6 \n\nTalk with Farmer Justin.  ";
                break;
            case 70:
                questInfoText.text = "MISSION 7 \n\nFollow the white path and reach the water well. Collect 3 rocks near the well and repair it, then come back to Farmer Justin. ";
                break;
            case 80:
                questInfoText.text = "MISSION 8 \n\nFollow the white path and come back to Farmer Justin. ";
                break;
            case 90:
                questInfoText.text = "MISSION 9 \n\nFind the dungeon entrance. Follow the black path. ";
                break;
            case 100:
                questInfoText.text = "MISSION 10 \n\nFind a way for reaching the treasure chest.";
                break;
            case 110:
                questInfoText.text = "MISSION 11 \n\nLeave the dungeon.";
                break;
            case 120:
                questInfoText.text = "MISSION 12 \n\nRUN!!\nThe farmers betrayed you. Reach your boat and sail to the Midwinter Island. Follow the black path.";
                break;
            case 130:
                questInfoText.text = "MISSION 13 \n\nFind a way to reach the portal in labyrinth.";
                break;
            case 140:
                questInfoText.text = "FINAL \n\nDefeat the boss and take the treasure!";
                break;
            default:
                questInfoText.text = "No mission";
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
                dialogueText.text = "The weather is weird these days, isn't it?";
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
                        dialogueText.text = "Once you have the five logs, take them to the village church and seek the guidance of the wise old Priest. He holds the knowledge to guide you further on your mission.";
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
                if (inventory.GetItemCount("Log") >= 5)
                {
                    switch (dialogueNumber)
                    {
                        case 0:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "Greetings, wise Priest. I have come bearing the logs as a donation to the village church, as instructed by Mr. Martin. I've completed the task given by Mr. Martin to reach the treasure. What is the next step, wise Priest?";
                            dialogueNumber = 10;
                            break;
                        case 10:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Ah, young warrior, your spirit and determination shine bright. At the summit of the treacherous mountain lies a hidden treasure—a Sacred Oar. It is said to possess remarkable powers. Retrieve this oar, for it will be a key to unveiling the secrets you seek.";
                            dialogueNumber = 20;
                            break;
                        case 20:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "A Sacred Oar? I had no knowledge of it. How can I reach it, wise Priest?";
                            dialogueNumber = 30;
                            break;
                        case 30:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Journey to the mountain's peak, young warrior, and search for the Sacred Oar. Be wary of the dangers that await you, for fierce creatures guard the way. Trust your instincts and return safely with the oar.";
                            dialogueNumber = 40;
                            break;
                        case 40:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "I accept this challenge, wise priest. With your blessings and guidance, I will ascend the mountain and take the Sacred Oar.";
                            dialogueNumber = 50;
                            break;
                        case 50:
                            inventory.DeleteItemCount("Log", 5);
                            DeactiveDialogue();
                            values.quest = 40;
                            break;
                    }
                }
                else
                {
                    switch (dialogueNumber)
                    {
                        case 0:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Let's see the logs first, kid!";
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
                        dialogueText.text = "The weather is weird these days, isn't it?";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        DeactiveDialogue();
                        break;
                }
                break;

            case 40:
                if (paddle.didPaddle) //kürek kontrolü
                {
                    switch (dialogueNumber)
                    {
                        case 0:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "Hello again wise Priest. I got the Sacred Oar you mentioned.";
                            dialogueNumber = 10;
                            break;
                        case 10:
                            dialogueNameText.text = "Priest";
                            dialogueText.text = "Great! I believed you could make it. But the real adventure begins now, there is a boat waiting for you at the pier. Board this boat to the next island. I trust you, good luck in your adventure!";
                            dialogueNumber = 20;
                            break;
                        case 20:
                            dialogueNameText.text = activeName;
                            dialogueText.text = "Thank you, I won't let you down.";
                            dialogueNumber = 30;
                            break;
                        case 30:
                            values.quest = 50;
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
                            dialogueText.text = "You haven't found the Sacred Oar yet";
                            dialogueNumber = 10;
                            break;
                        case 10:
                            DeactiveDialogue();
                            break;
                    }
                }
                break;

            case 60:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = "FarmerJustin";
                        dialogueText.text = " I see you've arrived on the desert island. Welcome, kid. I guess you are searching for the treasure. I can help you, but first I need your help. Our water well is broken, if you repair it I will give you some information about treasure.";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Sure, I will help you. What should I do?";
                        dialogueNumber = 20;
                        break;
                    case 20:
                        dialogueNameText.text = "FarmerJustin";
                        dialogueText.text = "Follow the white path, you will see the water well. You have to use 3 rocks for repairing it. Collect these rocks near the well and use them for repairing. Then come back for your reward. Good luck!";
                        dialogueNumber = 30;
                        break;
                    case 30:
                        values.quest = 70;
                        DeactiveDialogue();
                        break;
                }
                break;

            case 80:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Sir, I repaired the water well.";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        dialogueNameText.text = "FarmerJustin";
                        dialogueText.text = "Good job! I liked you kid, now listen carefully. I don't know the exact location of the treasure, we were searching it for weeks. But we found a dungeon entrance, there's definitely something valuable inside.  ";
                        dialogueNumber = 20;
                        break;
                    case 20:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "How can I go there?";
                        dialogueNumber = 30;
                        break;
                    case 30:
                        dialogueNameText.text = "FarmerJustin";
                        dialogueText.text = "Follow the black path, it will take you to the entrance. But be careful, it's very dangerous. We'll be waiting for you outside just in case. ";
                        dialogueNumber = 40;
                        break;
                    case 40:
                        dialogueNameText.text = activeName;
                        dialogueText.text = "Thank you for your help, sir. See you soon.";
                        dialogueNumber = 50;
                        break;
                    case 50:
                        values.quest = 90;
                        DeactiveDialogue();
                        break;      
                }
                break;
            case 100:
                switch (dialogueNumber)
                {
                    case 0:
                        dialogueNameText.text = "?????";
                        dialogueText.text = "You, the brave warrior! Use the door to return to Island but beware of enemy villagers, they will try to kill you. Reach the boat immediately, and travel to Midwinter Island. The great treasure is waiting for you.";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        values.quest = 110;
                        DeactiveDialogue();
                        break;      //////////////////////////HERE******************************************
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
