using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //SoundManager SoundManagerskeletonhurt;
    //SoundManager SoundManagerskeletondead;
    [SerializeField] float health = 3f;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    Animator animator;
    UnityEngine.AI.NavMeshAgent agent;
    float timePassed;
    float newDestinationCD = 0.5f;

    void Start()
    {
        //SoundManagerskeletonhurt = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        //SoundManagerskeletondead = GameObject.Find("Sound Manager").GetComponent<SoundManager>(); 
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        /*if (player == null)
            return;*/
        HealthSystem healthSystem = FindObjectOfType<HealthSystem>();

        if (healthSystem != null && healthSystem.isDead != true)
        {
            if (timePassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    animator.SetTrigger("attack");
                    timePassed = 0;
                }
            }
            timePassed += Time.deltaTime;

            if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                newDestinationCD = 0.5f;
                agent.SetDestination(player.transform.position);
            }
            newDestinationCD -= Time.deltaTime;
            transform.LookAt(player.transform);
        }
    }



    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        CameraShake.Instance.ShakeCamera(1f, 0.2f); //CAMERA SHAKE
        //SoundManagerskeletonhurt.Skeletonhurt();

        if (health <= 0)
        {
            Die();
            //SoundManagerskeletondead.Skeletondead();
        }
    }

    void Die()
    {
        EndDealDamage();
        // Instantiate(ragdoll, transform.position,transform.rotation);
        // Destroy(this.gameObject);
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        animator.SetBool("Die", true);
        enabled = false;
        Invoke("DestroyEnemy", 10f);
    }

    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }


    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }


    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
