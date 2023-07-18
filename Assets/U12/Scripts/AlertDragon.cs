using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDragon : MonoBehaviour
{
    SoundManager soundManagerDragonroar; 
    public Animator _animator;

    private GameObject dragonBarPanel;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        soundManagerDragonroar = FindObjectOfType<SoundManager>();

        dragonBarPanel = GameObject.Find("DragonBarPanel");
        dragonBarPanel.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
    {
        dragonBarPanel.SetActive(true);
        _animator.SetTrigger("Alert");
        soundManagerDragonroar.Dragonroar();
    }
}
