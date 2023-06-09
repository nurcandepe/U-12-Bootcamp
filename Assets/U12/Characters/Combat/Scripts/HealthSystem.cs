using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject hitVFX;
    //[SerializeField] GameObject ragdoll;

    Animator animator;
    public bool isDead = false;
    public Enemy enemy;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        CameraShake.Instance.ShakeCamera(1f, 0.2f); //CAMERA SHAKE

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("isDead");
        health = 100;

        ThirdPersonController tpsController = GetComponent<ThirdPersonController>();
        if(tpsController != null)
        {
            tpsController.enabled = false;
        }
    }

    public void StopDie()
    {
        animator.SetBool("DeadBool",true);
    }
    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);

    }   
}
