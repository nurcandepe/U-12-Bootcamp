using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercation : MonoBehaviour
{
    private bool canHit = false;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (canHit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _animator.SetBool("hitTree", true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            //Debug.Log("Agac ");
            canHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Agac cikti");
        if (other.gameObject.CompareTag("Tree"))
        {
            //Debug.Log("Agactan cikildi");
            canHit = false;
        }
    }

    public void DestroyTree()
    {
        canHit = false;
        _animator.SetBool("hitTree", false);
    }
}
