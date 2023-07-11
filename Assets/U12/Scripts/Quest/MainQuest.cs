using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class MainQuest : MonoBehaviour
{
    public SOValues values;

    //Sa�daki g�rev takip paneli
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

    void Start()
    {
        questNumber = values.quest;

        //Sa�daki g�rev takip paneli
        questInfoPanel = GameObject.Find("QuestInfoPanel");
        questInfoText = GameObject.Find("QuestInfoText").GetComponent<TextMeshProUGUI>();

        //diyalog paneli
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialogueNameText = GameObject.Find("DialogueNameText").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        //ba�lang��ta diyalog panelini kapat�yoruz ve s�f�rl�yoruz
        dialoguePanel.SetActive(false);
        dialogueNumber = 0;

        questInfoText.text = "�lk G�revin";

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
                        dialogueText.text = "�ok zor durumday�z. Yard�m et!";
                        dialogueNumber = 10;
                        break;
                    case 10:
                        dialogueText.text = "Bitti.";
                        dialogueNumber = 20;
                        break;
                    case 20:
                        dialoguePanel.SetActive(false);
                        dialogueNumber = 0;
                        tpController.enabled = true;
                        animator.SetBool("npcTalk", false);
                        break;
                }
                break;
            default:
                dialogueText.text = "Bug�nlerde hava bir garip...";
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
            ChangeDialogue();
        }
    }

    //Do�ru npc ile konu�up konu�mad���m�z� d�nd�r�yor
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
}
