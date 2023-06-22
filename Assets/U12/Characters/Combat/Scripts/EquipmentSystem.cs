using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;

    [SerializeField] GameObject shieldHolder;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject shieldSheath;

    GameObject currentWeaponInSheath;
    GameObject currentWeaponInHand;

    GameObject shieldInSheath;
    GameObject shieldInHand;

    public Animator _animator;

    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        shieldInSheath = Instantiate(shield, shieldSheath.transform);
        _animator = GetComponent<Animator>();
    }

    public void DrawShield()
    {
        shieldInHand = Instantiate(shield, shieldHolder.transform);
        Destroy(shieldInSheath);
    }

    public void SheathShield()
    {
        shieldInSheath = Instantiate(shield, shieldSheath.transform);
        Destroy(shieldInHand);
    }

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSheath);
    }

    public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
    }

    public void StartDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }

    public void CombatOff()
    {
        CombatScript combatScript = GetComponent<CombatScript>();
        if (combatScript != null)
        {
            combatScript.enabled = false;
        }
    }

    public void CombatOn()
    {
        CombatScript combatScript = GetComponent<CombatScript>();
        if (combatScript != null)
        {
            combatScript.enabled = true;
        }
    }

    public void ShieldImpactOff()
    {
        _animator.SetBool("BlockImpact", false);
    }
}
