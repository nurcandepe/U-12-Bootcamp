using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    SoundManager soundManagerDragondeath;
    SoundManager soundManagerDragonhurt;
    private Animator _animatorParent;
    [SerializeField] float dragonHealth = 5f;
    private bool isInsideCollider = false;

    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPosition; //***///*/*
    [SerializeField] GameObject invisibleWall;

    void Start()
    {
        soundManagerDragondeath = FindObjectOfType<SoundManager>();
        soundManagerDragonhurt = FindObjectOfType<SoundManager>();
        _animatorParent = GetComponentInParent<Animator>();
        invisibleWall.SetActive(true);
    }

    void Update()
    {
        if(dragonHealth <= 0)
        {
            _animatorParent.SetBool("isAttacking", false);
            _animatorParent.SetTrigger("DragonDie");
            soundManagerDragondeath.DragonDeath();
            invisibleWall.SetActive(false);
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
            soundManagerDragonhurt.DragonHurt();
            //Debug.Log("hit");
        }
    }

    private void HitVFXDragon()
    {
        GameObject hit = Instantiate(hitVFX, hitPosition.transform);
        Destroy(hit, 3f);
    }

}
