using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamageNear : MonoBehaviour
{
    public bool canFlameNear = false;
    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPosition; //***///*/*

    void Start()
    {
        canFlameNear = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem health = FindObjectOfType<HealthSystem>();
        if (!canFlameNear)
        {
            if (other.CompareTag("Player"))
            {
                health.TakeDamage(weaponDamage);
                HitVFX();
                //canFlameNear = true;
            }

        }

        /*if (other.CompareTag("Player"))
        {
            Debug.Log("DAMAGE Near");
        }*/
    }

    private void HitVFX()
    {
        GameObject hit = Instantiate(hitVFX, hitPosition.transform);
        Destroy(hit, 3f);
    }
    
}
