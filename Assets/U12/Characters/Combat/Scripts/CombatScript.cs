using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatScript : MonoBehaviour
{
    /*private Animator anim;
    public float cooldownTime = 2.0f;
    private float nextFireTime = 0.0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0.0f;
    float maxComboDelay = 1.0f;

    private bool isSwordDrawed; //old

    void Start()
    {
        anim = GetComponent<Animator>();
        isSwordDrawed = false; //old
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            //    anim.SetBool("hit1", false);
            //anim.SetTrigger("Attack");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            //    anim.SetBool("hit2", false);
           // anim.SetTrigger("Attack");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            //    anim.SetBool("hit3", false);
           // anim.SetTrigger("Attack");
           // noOfClicks = 0;
        }

        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if(Time.time > nextFireTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isSwordDrawed == false)
            {
                anim.SetTrigger("DrawSword");
                isSwordDrawed = true;
            }

            else if (isSwordDrawed == true)
            {
                anim.SetTrigger("SheathSword");
                isSwordDrawed = false;
            }

        }
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if(noOfClicks == 1)
        {
            //anim.SetBool("hit1", true);
            anim.SetTrigger("Attack");
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            //anim.SetBool("hit1", false);
            // anim.SetBool("hit2", true);
            anim.SetTrigger("Attack");
        }

        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            //anim.SetBool("hit2", false);
            // anim.SetBool("hit3", true);
            anim.SetTrigger("Attack");
        }
    }

    */











    public Animator _animator;
    private bool isSwordDrawed;
    private bool isBowDrawed;

    public bool isBlocking;

    void Start()
    {
        _animator = GetComponent<Animator>();
        isSwordDrawed = false;
        isBowDrawed = false;

        isBlocking = false;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            if (isBowDrawed == false)
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
            else if (isBowDrawed == true)
            {
                if (isSwordDrawed == false)
                {
                    //_animator.SetBool("Changing",true);
                    _animator.SetBool("BowInHand", false);
                    _animator.SetBool("SwordInHand", true);
                    _animator.SetTrigger("SheathBow");
                    _animator.SetTrigger("DrawSword");
                    isBowDrawed = false;
                    isSwordDrawed = true;

                    

                }

               /* else if (isSwordDrawed == true)
                {
                    _animator.SetTrigger("SheathSword");
                    isSwordDrawed = false;
                }*/
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
        if(isSwordDrawed == false)
            {
                if (isBowDrawed == false)
                {
                    _animator.SetTrigger("DrawBow");
                    isBowDrawed = true;
                    _animator.SetBool("BowInHand", true);
                }

                else if (isBowDrawed == true)
                {
                    _animator.SetTrigger("SheathBow");
                    isBowDrawed = false;
                    _animator.SetBool("BowInHand", false);
                }
            }
        else if(isSwordDrawed == true)
            {
                if (isBowDrawed == false)
                {
                    //_animator.SetBool("Changing",true);
                    _animator.SetBool("SwordInHand", false);
                    _animator.SetBool("BowInHand", true);
                    _animator.SetTrigger("SheathSword");
                    _animator.SetTrigger("DrawBow");
                    isSwordDrawed = false;
                    isBowDrawed = true;
                   
                    
                }

               /* else if (isBowDrawed == true)
                {
                    _animator.SetTrigger("SheathBow");
                   isBowDrawed = false;
                }*/
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
