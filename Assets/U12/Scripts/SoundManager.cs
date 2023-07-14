using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip injured;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Injured()
    {
        audioSource.PlayOneShot(injured);
    }
}
