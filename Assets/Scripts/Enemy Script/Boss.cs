using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float maxHealth = 20;
    float currentHealth;

    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    [SerializeField] UIBossHealthBar bossHealthBar;

    GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    float timePassed;
    float newDestinationCD = 0.5f;

    [SerializeField] private HealthScript HPscript;
    public float MaxHealth { get { return maxHealth; } }
    public float CurrentHealth { get { return currentHealth; } }

    public bool isBoss;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        agent  = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        bossHealthBar = FindObjectOfType<UIBossHealthBar>();
        currentHealth = HPscript.HP;
    }


    void Start()
    {   
        if(!isBoss){
            bossHealthBar.SetBossMaxHealth(HPscript.HP);
        }
        
    }



    void Update()
    {
        animator.SetFloat("speed",agent.velocity.magnitude / agent.speed);

        if(timePassed >= attackCD)
        {
            if(Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;

        if(newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            agent.SetDestination(player.transform.position);
            newDestinationCD = 0.5f;
        }
        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);
    }

    public void TakeDamage(float damageAmount)
    {
        HPscript.HP -= damageAmount;
        animator.SetTrigger("damage");

        if (currentHealth <= 0)
        {
            Die();   
        }
    }
    
    void Die()
    {
       Destroy(this.gameObject);
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
}
