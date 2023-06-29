using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] GameObject leverHolder;
    [SerializeField] GameObject leverClosed;
    [SerializeField] GameObject leverOpen;

    [SerializeField] GameObject invisibleDoorHolder;
    [SerializeField] GameObject invisibleDoor;
    [SerializeField] GameObject treasureDoorHolder;
    [SerializeField] GameObject treasureDoor;

    GameObject openLever;
    GameObject closedLever;
    GameObject treaDoor;
    GameObject invisDoor;

    private bool CanLever;
    private bool LeverCount;

    void Start()
    {
        closedLever = Instantiate(leverClosed, leverHolder.transform);
        invisDoor = Instantiate(invisibleDoor, invisibleDoorHolder.transform);
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
                    Destroy(invisDoor);
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
