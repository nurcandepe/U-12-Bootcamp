using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    public bool hasDealtDamage;

    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPosition; //***///*/*

    void Start()
    {
        //canDealDamage = false;
        hasDealtDamage = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        CombatScript combatScript = FindObjectOfType<CombatScript>();
        HealthSystem health = FindObjectOfType<HealthSystem>();
        Enemy enemy = FindObjectOfType<Enemy>();



        if (!hasDealtDamage)
        {
            if (combatScript.isBlocking != true)
            {
               //Debug.Log("enemy has dealt damage");
               health.TakeDamage(weaponDamage);
               HitVFX();
               //enemy.HitVFX(bloodPos.transform.position);
               hasDealtDamage = true;
            }
            else if (combatScript.isBlocking == true)
            {
                combatScript.BlockTrigger();
            }
        }
    }

    public void StartDragonDamage()
    {
       // canDealDamage = true;
        hasDealtDamage = false;
    }
    public void EndDragonDamage()
    {
       // canDealDamage = false;
        hasDealtDamage = false;
    }

    private void HitVFX()
    {
        GameObject hit = Instantiate(hitVFX, hitPosition.transform);
        Destroy(hit, 3f);
    }
}
