using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    [SerializeField] float health = 3f;
    [SerializeField] GameObject hitVFX;
    SoundManager soundManagermonsterroar;
    SoundManager soundManagermonsterdead;
    //[SerializeField] GameObject ragdoll;

    public GameObject damageDealer;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    GameObject player;
    public Animator __animator;
    UnityEngine.AI.NavMeshAgent agent;
    float timePassed;
    float newDestinationCD = 0.5f;

    private bool isDeadBear = false;

    void Start()
    {
        // soundManagermonsterroar = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        // soundManagermonsterdead = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        player = GameObject.Find("PlayerArmature");
        __animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        damageDealer.SetActive(false);
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



    public void TakeDamageBear(float damageAmount)
    {
        if (isDeadBear == false)
        {
            health -= damageAmount;
            __animator.SetTrigger("damage");
            CameraShake.Instance.ShakeCamera(1f, 0.2f); //CAMERA SHAKE
            //soundManagermonsterroar.Monsterroar();

            if (health <= 0)
            {
                Die();
                //soundManagermonsterdead.Mosterdead();
                isDeadBear = true;
            }
        }

    }

    void Die()
    {
        //Debug.Log("DEAD");
        __animator.SetBool("Die", true);
        CapsuleCollider colliderBear = GetComponent<CapsuleCollider>();
        colliderBear.enabled = false;
        enabled = false;
        EndDealDamage();
        isDeadBear = true;
        Invoke("DestroyBear", 10f);


    }

    public void StartDealDamage()
    {
        damageDealer.SetActive(true);
        BearDamageDealer bearDamage = FindObjectOfType<BearDamageDealer>();
        bearDamage.hasDealtDamage = false;

    }

    public void EndDealDamage()
    {
        BearDamageDealer bearDamage = FindObjectOfType<BearDamageDealer>();
        damageDealer.SetActive(false);
        bearDamage.hasDealtDamage = true;
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

    private void DestroyBear()
    {
        Destroy(gameObject);
    }

}
