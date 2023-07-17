using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonClawAttack : MonoBehaviour
{
    SoundManager Soundmanagerattack; 
    private Animator _animator;

    void Start()
    {
        Soundmanagerattack = FindObjectOfType<SoundManager>();
        _animator = GetComponentInParent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("isAttacking", true);
        Soundmanagerattack.DragonJumpAttack();
    }
}
