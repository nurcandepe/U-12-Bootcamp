using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDragon : MonoBehaviour
{
    SoundManager soundManagerDragonroar; 
    public Animator _animator;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        soundManagerDragonroar = FindObjectOfType<SoundManager>();
    }


    public void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Alert");
        soundManagerDragonroar.Dragonroar();
    }
}
