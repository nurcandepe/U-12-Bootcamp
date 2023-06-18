using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        CombatScript combatScript = FindObjectOfType<CombatScript>();

        if (canDealDamage && !hasDealtDamage)
        {
            if(combatScript.isBlocking != true)
            {
                RaycastHit hit;

                int layerMask = 1 << 8;
                if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
                {
                    if (hit.transform.TryGetComponent(out HealthSystem health))
                    {
                        // //debug // print("enemy has dealt damage");
                        health.TakeDamage(weaponDamage);
                        health.HitVFX(hit.point);
                        hasDealtDamage = true;
                    }
                }
            }
        }
    }
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
