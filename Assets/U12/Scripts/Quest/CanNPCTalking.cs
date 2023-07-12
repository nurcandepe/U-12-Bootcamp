using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanNPCTalking : MonoBehaviour
{

    private CapsuleCollider capsuleCollider;
    public SOValues values;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        
    }
}
