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

    void Start()
    {
        _animator = GetComponent<Animator>();
        isSwordDrawed = false;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            if (isSwordDrawed == false)
            {
                _animator.SetTrigger("DrawSword");
                isSwordDrawed = true;
            }

            else if (isSwordDrawed == true)
            {
                _animator.SetTrigger("SheathSword");
                isSwordDrawed = false;
            }

            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            if (isSwordDrawed == true)
            {
                _animator.SetTrigger("Attack");
            }
            }
    }
}
