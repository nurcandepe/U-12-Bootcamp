using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    private Animator _animatorParent;
    [SerializeField] float dragonHealth = 5f;
    private bool isInsideCollider = false;

    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPosition; //***///*/*

    void Start()
    {
        _animatorParent = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if(dragonHealth <= 0)
        {
            _animatorParent.SetBool("isAttacking", false);
            _animatorParent.SetTrigger("DragonDie");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInsideCollider = true;
        //Debug.Log("INSIDE");
    }
    private void OnTriggerExit(Collider other)
    {
        isInsideCollider = false;
        //Debug.Log("not INSIDE");
    }

    public void HitDragon()
    {
        if (isInsideCollider)
        {
            HitVFXDragon();
            dragonHealth -= 1f;
            Debug.Log("hit");
        }
    }

    private void HitVFXDragon()
    {
        GameObject hit = Instantiate(hitVFX, hitPosition.transform);
        Destroy(hit, 3f);
    }

}
