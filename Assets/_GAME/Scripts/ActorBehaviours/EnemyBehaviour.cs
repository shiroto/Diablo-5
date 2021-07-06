using System;
using System.Collections;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : BaseEntity
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Collider attackArea;
    [SerializeField] private Animator animator;
    
    private bool isAttacking = false;
    private Transform player;

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

    void Update()
    {
        if (isAttacking)
        {
            navAgent.speed = 0;
            navAgent.angularSpeed = 120;
        }
        else
        {
            navAgent.speed = 3.5f;
            navAgent.angularSpeed = 360000;
            FollowPlayer();
        }

        animator.SetBool("isAttacking", isAttacking);
        animator.SetFloat("velocity", navAgent.velocity.magnitude);


        // float healthRatio = Health / MaxHealth;
        // navMeshAgent.speed = speedByHealth.Evaluate(healthRatio) * speedMultiplier;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Attack()
    {
        Debug.Log("ATTACK NOW!");
        isAttacking = true;

        yield return new WaitForSeconds(2);

        attackArea.enabled = true;

        yield return null;
        yield return null;
        yield return null;

        isAttacking = false;
    }

    private void FollowPlayer()
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