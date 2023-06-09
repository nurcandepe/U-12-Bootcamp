using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasualEnemy : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] GameObject hitVFX;
    //[SerializeField] GameObject ragdoll;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    public Animator __animator;
    UnityEngine.AI.NavMeshAgent agent;
    float timePassed;
    float newDestinationCD = 0.5f;

    private bool isDeadCasual = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        __animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        __animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        /*if (player == null)
            return;*/
        HealthSystem healthSystem = FindObjectOfType<HealthSystem>();

        if (healthSystem != null && healthSystem.isDead != true)
        {
            if (timePassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    __animator.SetTrigger("attack");
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



    public void TakeDamageCasual(float damageAmount)
    {
        if (isDeadCasual == false)
        {
            health -= damageAmount;
            __animator.SetTrigger("damage");
            CameraShake.Instance.ShakeCamera(1f, 0.2f); //CAMERA SHAKE

            if (health <= 0)
            {
                Die();
                isDeadCasual = true;
            }
        }

    }

    void Die()
    {
       // Debug.Log("DEAD");
        __animator.SetBool("Die", true);
        EndDealDamage();

        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;

        enabled = false;

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

}
