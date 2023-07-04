using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DragonScript : MonoBehaviour
{
    public GameObject flamethrowerEffect;
    public GameObject damageDealerTrigger;
   [SerializeField] GameObject flameThrowerHolder;
    GameObject flame;

    public GameObject flameNear;
    public GameObject flameFar;

    private bool isFlamethrowerActive = false;

    private void Start()
    {
        damageDealerTrigger.SetActive(false);
        flameNear.SetActive(false);
    }

    private void Update()
    {
    }

    public void StartFlameThrower()
    {
        flame = Instantiate(flamethrowerEffect, flameThrowerHolder.transform);
        isFlamethrowerActive = true;
    }

    public void StopFlameThrower()
    {
        flamethrowerEffect.SetActive(false);
        isFlamethrowerActive = false;
    }


    public void StartMeleeDamage()
    {
        DragonDamageDealer dragon = FindObjectOfType<DragonDamageDealer>();
        dragon.StartDragonDamage();
    }

    public void EndMeleeDamage()
    {
        DragonDamageDealer dragon = FindObjectOfType<DragonDamageDealer>();
        dragon.EndDragonDamage();
    }

    public void MeleeOff()
    {
        DragonDamageDealer dragon = damageDealerTrigger.GetComponent<DragonDamageDealer>();
        dragon.enabled = false;
        DragonDamageDealer dragon2 = FindObjectOfType<DragonDamageDealer>();
        dragon2.hasDealtDamage = false;
        damageDealerTrigger.SetActive(false);
    }

    public void MeleeOn()
    {
        DragonDamageDealer dragon = damageDealerTrigger.GetComponent<DragonDamageDealer>();
        dragon.enabled = true;
        damageDealerTrigger.SetActive(true);
    }

    public void FlameNearOn()
    {
        flameNear.SetActive(true);
    }

    public void FlameNearOff()
    {
        flameNear.SetActive(false);
    }

    public void FlameFarOn()
    {
        flameFar.SetActive(true);
    }

    public void FlameFarOff()
    {
        flameFar.SetActive(false);
    }

}
