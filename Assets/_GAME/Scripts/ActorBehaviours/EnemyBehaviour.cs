using System;
using System.Collections;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBehaviour : BaseEntity
{
    [SerializeField] protected NavMeshAgent navAgent;
    [SerializeField] protected Collider attackArea;
    [SerializeField] protected Animator animator;

    protected bool isAttacking = false;
    protected Transform player;

    public AnimationCurve speedByHealth;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        attackArea.enabled = false;
    }
    
    protected virtual void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
        animator.SetFloat("velocity", navAgent.velocity.magnitude);
        
        // float healthRatio = Health / MaxHealth;
        // navMeshAgent.speed = speedByHealth.Evaluate(healthRatio) * speedMultiplier;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public abstract IEnumerator Attack();

    protected void FollowPlayer()
    {
        navAgent.destination = player.position;
    }


    public override float TakeDamage(float dmg, DamageTypes type)
    {
        float damageMultiplier = 1;

        if (isAttacking)
        {
            damageMultiplier = 2;
        }

        float effectiveDamage = dmg * damageMultiplier;

        Health -= effectiveDamage;
        return effectiveDamage;
    }
}