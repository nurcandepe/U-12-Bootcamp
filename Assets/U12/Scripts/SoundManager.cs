using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip injured;
    [SerializeField] AudioClip dragonroar;
    [SerializeField] AudioClip monsterroar;
    [SerializeField] AudioClip monsterdead;
    [SerializeField] AudioClip skeletonhurt;
    [SerializeField] AudioClip skeletondead;
    [SerializeField] AudioClip swing;
    [SerializeField] AudioClip blok;
    [SerializeField] AudioClip dragondeath;
    [SerializeField] AudioClip dragonbreath;
    [SerializeField] AudioClip dragonjumpattack;
    [SerializeField] AudioClip dragonhurt;
    [SerializeField] AudioClip farmerhurt;
    [SerializeField] AudioClip farmerdie;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Injured()
    {
        audioSource.PlayOneShot(injured);
    }

    public void Dragonroar()
    {
        audioSource.PlayOneShot(dragonroar);
    }
    public void Monsterroar()
    {
        audioSource.PlayOneShot(monsterroar);
    }
    public void Mosterdead() 
    {
        audioSource.PlayOneShot(monsterdead);
    }
    public void Skeletonhurt()
    {
        audioSource.PlayOneShot(skeletonhurt);
    }
    public void Skeletondead()
    {
        audioSource.PlayOneShot(skeletondead);
    }
    public void Swing()
    {
        audioSource.PlayOneShot(swing);
    }
    public void Blok()
    {
        audioSource.PlayOneShot(blok);
    }
    public void DragonDeath()
    {
        audioSource.PlayOneShot(dragondeath);
    }
    public void Dragonbreath()
    {
        audioSource.PlayOneShot(dragonbreath);
    }
    public void DragonJumpAttack()
    {
        audioSource.PlayOneShot(dragonjumpattack);
    }
    public void DragonHurt()
    {
        audioSource.PlayOneShot(dragonhurt);  
    }
    public void Farmerhurt()
    {
        audioSource.PlayOneShot(farmerhurt);
    }
    public void Farmerdie()
    {
        audioSource.PlayOneShot(farmerdie);
    }
}
