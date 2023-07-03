using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethAttack : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("TeethAttack");
    }
}
