using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    SoundManager soundManagerDragondeath;
    SoundManager soundManagerDragonhurt;
    private Animator _animatorParent;
    [SerializeField] float dragonHealth = 8f;
    private bool isInsideCollider = false;

    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPosition; //***///*/*
    [SerializeField] GameObject invisibleWall;

    private GameObject dragonBar;

    void Start()
    {
        soundManagerDragondeath = FindObjectOfType<SoundManager>();
        soundManagerDragonhurt = FindObjectOfType<SoundManager>();
        _animatorParent = GetComponentInParent<Animator>();
        invisibleWall.SetActive(true);

        dragonBar = GameObject.Find("DragonBar");
    }

    void Update()
    {
        if(dragonHealth <= 0)
        {
            _animatorParent.SetBool("isAttacking", false);
            _animatorParent.SetTrigger("DragonDie");
            soundManagerDragondeath.DragonDeath();
            invisibleWall.SetActive(false);
            dragonBar.transform.localScale = new Vector3((0f), 1f, 1f);
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
            dragonBar.transform.localScale = new Vector3((dragonHealth / 8f), 1f, 1f);
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
