using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderCont : MonoBehaviour
{
    public SOValues values;

    private GameObject male;
    private GameObject female;

    private void Awake()
    {
        female = GameObject.Find("Player_Women");
        male = GameObject.Find("Player_Men");

        if (values.gender == "male")
        {
            //Bir hatadan dolayý ikisini kapatýp birini açýnca düzgün çalýþýyor
            female.SetActive(false);
            male.SetActive(false);

            male.SetActive(true);
        }
        else
        {
            //Bir hatadan dolayý ikisini kapatýp birini açýnca düzgün çalýþýyor
            female.SetActive(false);
            male.SetActive(false);

            female.SetActive(true);
        }
    }
    void Start()
    {
       
    }

    void Update()
    {
        
    }
}
