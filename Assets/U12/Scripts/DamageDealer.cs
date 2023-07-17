using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    //Debug.Log("damage");
                    enemy.TakeDamage(weaponDamage);
                    enemy.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }

                else if (hit.transform.TryGetComponent(out CasualEnemy enemyC) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    //Debug.Log("damage");
                    enemyC.TakeDamageCasual(weaponDamage);
                    enemyC.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }

                else if (hit.transform.TryGetComponent(out BearScript enemyB) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    //Debug.Log("damageBEAR");
                    enemyB.TakeDamageBear(weaponDamage);
                    enemyB.HitVFX(hit.point);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
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
