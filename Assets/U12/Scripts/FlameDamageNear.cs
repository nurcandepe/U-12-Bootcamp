using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamageNear : MonoBehaviour
{
    public bool canFlameNear = false;
    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPositionMan;
    [SerializeField] GameObject hitPositionWoman;//***///*/*

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
        if (hitPositionMan != null)
        {
            GameObject hit = Instantiate(hitVFX, hitPositionMan.transform);
            Destroy(hit, 3f);
        }

        if (hitPositionWoman != null)
        {
            GameObject hit = Instantiate(hitVFX, hitPositionWoman.transform);
            Destroy(hit, 3f);
        }
    }
    
}
