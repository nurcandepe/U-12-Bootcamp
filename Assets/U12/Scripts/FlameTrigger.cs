using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    SoundManager soundManagerDragonbreath; 
    private Animator _animator;

    void Start()
    {
        soundManagerDragonbreath = FindObjectOfType<SoundManager>(); 
        _animator = GetComponentInParent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("isFlaming", true);
        soundManagerDragonbreath.Dragonbreath();
    }
}
