using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBoss : MonoBehaviour
{
    [SerializeField] GameObject leverHolder;
    [SerializeField] GameObject leverClosed;
    [SerializeField] GameObject leverOpen;

    [SerializeField] GameObject treasureDoorHolder;
    [SerializeField] GameObject treasureDoor;

    GameObject openLever;
    GameObject closedLever;
    GameObject treaDoor;

    private bool CanLever;
    private bool LeverCount;

    void Start()
    {
        closedLever = Instantiate(leverClosed, leverHolder.transform);
        treaDoor = Instantiate(treasureDoor, treasureDoorHolder.transform);
        CanLever = false;
        LeverCount = true;
    }

    void Update()
    {
        if (CanLever)
        {
            if (LeverCount)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(closedLever);
                    openLever = Instantiate(leverOpen, leverHolder.transform);
                    Destroy(treaDoor);
                    LeverCount = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Can Lever");
        CanLever = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Can NOT Lever");
        CanLever = false;
    }
}
