using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DragonScript : MonoBehaviour
{
    public GameObject flamethrowerEffect;
    //public GameObject smokeEffect;
    [SerializeField] GameObject flameThrowerHolder;
    GameObject flame;
    //GameObject smoke;

    private bool isFlamethrowerActive = false;

    private void Start()
    {
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

}
