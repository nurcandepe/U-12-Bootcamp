using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;

    [SerializeField] GameObject bowHolder;
    [SerializeField] GameObject bow;
    [SerializeField] GameObject bowSheath;

    GameObject currentWeaponInSheath;
    GameObject currentWeaponInHand;
    GameObject currentWeaponInBowSheath;

    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        currentWeaponInBowSheath = Instantiate(bow, bowSheath.transform);
    }

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        Destroy(currentWeaponInSheath);
    }

    public void DrawBow()
    {
        currentWeaponInHand = Instantiate(bow, bowHolder.transform);
        Destroy(currentWeaponInBowSheath);
    }


    public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
    }

    public void SheathBow()
    {
        currentWeaponInBowSheath = Instantiate(bow, bowSheath.transform);
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
}
