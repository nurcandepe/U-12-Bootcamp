using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamageFar : MonoBehaviour
{
    public bool canFlameFar = false;
    [SerializeField] float weaponDamage;
    [SerializeField] GameObject hitVFX; //***///*/*
    [SerializeField] GameObject hitPositionMan; //***///*/*
    [SerializeField] GameObject hitPositionWoman;

    void Start()
    {
        canFlameFar = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem health = FindObjectOfType<HealthSystem>();
        if (!canFlameFar)
        {
            if (other.CompareTag("Player"))
            {
                health.TakeDamage(weaponDamage);
                HitVFX();
                //canFlameFar = true;
            }

        }

        /*if (other.CompareTag("Player")) 
        {
            Debug.Log("DAMAGE far"); 
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
