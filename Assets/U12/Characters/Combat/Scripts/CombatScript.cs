using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatScript : MonoBehaviour
{
    public Animator _animator;
    public bool isSwordDrawed;
    public bool isBlocking;


    void Start()
    {
        _animator = GetComponent<Animator>();
        isSwordDrawed = false;
        isBlocking = false;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                if (isSwordDrawed == false)
                {
                    _animator.SetTrigger("DrawSword");
                    isSwordDrawed = true;
                    _animator.SetBool("SwordInHand", true);
                    
                }

                else if (isSwordDrawed == true)
                {
                    _animator.SetTrigger("SheathSword");
                    isSwordDrawed = false;
                    _animator.SetBool("SwordInHand", false);   
                }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            if (isSwordDrawed == true)
            {
                _animator.SetTrigger("Attack");
            }
            }

            if (Input.GetMouseButtonDown(1))
            {
            if (isSwordDrawed == true)
            {
                _animator.SetBool("isBlocking", true);
                isBlocking = true;
            }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                _animator.SetBool("isBlocking", false);
                isBlocking = false;
            }


 
    }
    public void BlockTrigger()
    {
        _animator.SetBool("BlockImpact", true);
    }

    public void BlockTriggerOFF()
    {
        _animator.SetBool("BlockImpact", false);
    }

}
