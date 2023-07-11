using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    private bool canHit = false;
    private bool canBreak = false;
    private bool canTalk = false;

    private Animator _animator;
    private bool isHitting = false;
    private Transform _transform;

    private GameObject triggeredObject;

    private GameObject interactPanel;
    private TextMeshProUGUI interactText;

    [SerializeField] GameObject axeHolder;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject pickaxe;
    GameObject axeInHand;

    private GameObject tempObject;
    public GameObject log;
    public GameObject stone;

    void Start()
    {
        interactPanel = GameObject.Find("InteractionPanel");
        interactText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();

        _animator = GetComponentInParent<Animator>();
        interactPanel.SetActive(false);
        //_transform = GetComponentInParent<Transform>();
    }

    void Update()
    {
        CombatScript combatScript = FindObjectOfType<CombatScript>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHit)
            {
                if (combatScript.isSwordDrawed != true)
                {
                    if (isHitting != true)
                    {
                        _animator.SetBool("hitTree", true);
                        isHitting = true;
                        axeInHand = Instantiate(axe, axeHolder.transform);
                        interactPanel.SetActive(false);
                    }
                }
            }
            else if (canBreak)
            {
                if (combatScript.isSwordDrawed != true)
                {
                    if (isHitting != true)
                    {
                        _animator.SetBool("hitRock", true);
                        isHitting = true;
                        axeInHand = Instantiate(pickaxe, axeHolder.transform);
                        interactPanel.SetActive(false);
                    }
                }
            }
            else if (canTalk)
            {

                Debug.Log("Konuþabilirim");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            //Debug.Log("Agac ");
            canHit = true;
            triggeredObject = other.gameObject;
            interactPanel.SetActive(true);
            interactText.text = "Kes";
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
            //Debug.Log("Rock");
            canBreak = true;
            triggeredObject = other.gameObject;
            interactPanel.SetActive(true);
            interactText.text = "Parçala";
        }
        else if (other.gameObject.CompareTag("Lever"))
        {
            triggeredObject = other.gameObject;
            interactPanel.SetActive(true);
            interactText.text = "Kullan";
        }
        else if (other.gameObject.CompareTag("NPC"))
        {
            triggeredObject = other.gameObject;
            interactPanel.SetActive(true);
            canTalk = true;
            interactText.text = "Konuþ";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
           // Debug.Log("Agactan cikildi");
            canHit = false;
            isHitting = false;
            interactPanel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
            //Debug.Log("Rock Out");
            canBreak = false;
            isHitting = false;
            interactPanel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Lever"))
        {
            interactPanel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("NPC"))
        {
            canTalk = false;
            interactPanel.SetActive(false);
        }
    }

    public void InteractionAnimatorConfigure()
    {
        canHit = false;
        _animator.SetBool("hitTree", false);
        _animator.SetBool("hitRock", false); 
        Destroy(axeInHand);
        //Destroy(triggeredObject);
        canHit = false;
        canBreak = false;
        isHitting = false;
    }

    public void DestroyTriggeredObject()
    {
        //Debug.Log(triggeredObject.tag);
        CreateObjects(triggeredObject);
        Destroy(triggeredObject);
        interactPanel.SetActive(false);
    }

    private void CreateObjects(GameObject other)
    {
        if (other.tag == "Tree")
        {
            tempObject = log;
        }
        else if(other.tag == "Rock")
        {
            tempObject = stone;
        }
            
        GameObject newObject = Instantiate(tempObject);
        newObject.transform.position = other.transform.position;
        newObject.SetActive(true);
    }
}