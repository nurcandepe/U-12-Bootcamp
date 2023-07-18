using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    SoundManager soundManagerScript;


    [SerializeField] float health = 8f;
    [SerializeField] GameObject hitVFX;
    //[SerializeField] GameObject ragdoll;

    public Animator animator;
    public bool isDead = false;
    //public Enemy enemy;

    private GameObject diePanel;
    private GameObject bar;
    private float barScale;

    void Start()
    {
        //soundManagerScript = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        animator = GetComponent<Animator>();

        bar = GameObject.Find("Bar");
        diePanel = GameObject.Find("DiePanel");
        diePanel.SetActive(false);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        bar.transform.localScale = new Vector3((health/8f), 1f, 1f);
        animator.SetTrigger("damage");
        CameraShake.Instance.ShakeCamera(1f, 0.2f); //CAMERA SHAKE
        //soundManagerScript.Injured();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        diePanel.SetActive(true);
        isDead = true;
        animator.SetTrigger("isDead");
        health = 8f;
        bar.transform.localScale = new Vector3((0f), 1f, 1f);

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
