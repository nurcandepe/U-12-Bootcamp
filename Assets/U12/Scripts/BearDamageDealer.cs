using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    public bool hasDealtDamage;

    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPositionMan; //***///*/*
    [SerializeField] GameObject hitPositionWoman;

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

    public void StartBearDamage()
    {
        // canDealDamage = true;
        hasDealtDamage = false;
    }
    public void EndBearDamage()
    {
        // canDealDamage = false;
        hasDealtDamage = false;
    }

    private void HitVFX()
    {
        if(hitPositionMan != null)
        {
            GameObject hit = Instantiate(hitVFX, hitPositionMan.transform);
            Destroy(hit, 3f);
        }

        if(hitPositionWoman != null)
        {
            GameObject hit = Instantiate(hitVFX, hitPositionWoman.transform);
            Destroy(hit, 3f);
        }
    }
}
