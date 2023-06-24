using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercation : MonoBehaviour
{
    private bool canHit = false;
    private bool canBreak = false;
    private Animator _animator;
    private bool isHitting = false;

    private GameObject triggeredObject;

    [SerializeField] GameObject axeHolder;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject pickaxe;
    GameObject axeInHand;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        CombatScript combatScript = FindObjectOfType<CombatScript>();

        if (canHit)
        {
          if(combatScript.isSwordDrawed != true)
            {
                if(isHitting != true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        _animator.SetBool("hitTree", true);
                        isHitting = true;
                        axeInHand = Instantiate(axe, axeHolder.transform);
                    }
               }
            }

        }
        else if (canBreak)
        {
            if (combatScript.isSwordDrawed != true)
            {
                if(isHitting != true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        _animator.SetBool("hitRock", true); 
                        isHitting = true;
                        axeInHand = Instantiate(pickaxe, axeHolder.transform);
                    }
               }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
           // Debug.Log("Agac ");
            canHit = true;
            triggeredObject = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
           // Debug.Log("Rock");
            canBreak = true;
            triggeredObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
           // Debug.Log("Agactan cikildi");
            canHit = false;
            isHitting = false;
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
           // Debug.Log("Rock Out");
            canBreak = false;
            isHitting = false;
        }
    }

    public void DestroyTree()
    {
        canHit = false;
        _animator.SetBool("hitTree", false);
        _animator.SetBool("hitRock", false); 
        Destroy(axeInHand);
        Destroy(triggeredObject);
        canHit = false;
        canBreak = false;
        isHitting = false;
    }
}
