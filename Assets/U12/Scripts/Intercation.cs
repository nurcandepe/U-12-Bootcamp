using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercation : MonoBehaviour
{
    private bool canHit = false;
    private Animator _animator;
    public bool isHitting = false;

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
                Debug.Log("E BASILDI ");
                _animator.SetBool("hitTree", true);
                isHitting = true;
               // _animator.SetBool("hitTree", false);

            }
        }

        
        if(isHitting = false)
        {
            Debug.Log("IPTAL DENENDI ");
            _animator.SetBool("hitTree", false);
        }
        
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Agac ");
            canHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Agac cikti");
        if (other.gameObject.CompareTag("Tree"))
        {
            canHit = false;
        }
    }

}
