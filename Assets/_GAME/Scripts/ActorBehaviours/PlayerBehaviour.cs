using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : BaseEntity
{
    [SerializeField] private LayerMask navigationLayer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject destinationIndicator;
    [SerializeField] private GameObject lightningAttack;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetDestinationToMousePosition();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LightningAttack();
        }

        if (destinationIndicator && hasReachedDestination())
        {
            destinationIndicator.SetActive(false);
        }
    }

    private bool hasReachedDestination()
    {
        // Debug.Log($"path pendng: {agent.pathPending}, remainingDistance: {agent.remainingDistance}, hasPath: {agent.hasPath}");
        if (agent.pathPending) return false;
        if (agent.remainingDistance > agent.stoppingDistance) return false;
        if (agent.hasPath) return false;
        
        return true;
    }
    
    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f, navigationLayer))
        {
            if (agent.SetDestination(hit.point))
            {
                destinationIndicator.transform.position = hit.point;
                destinationIndicator.SetActive(true);
            }
            else
            {
                Debug.Log("We here?");
            }
        }
    }

    void LightningAttack()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000f, navigationLayer))
        {
            GameObject lightning = Instantiate(lightningAttack, hit.point, Quaternion.identity);
            lightning.SetActive(true);
        }
    }
    
    // Returns effective damage taken
    public override float TakeDamage(float dmg, DamageTypes type)
    {
        float damageMultiplier = 1;

        if (type == DamageTypes.Kinetic)
        {
            damageMultiplier = 1.5f;
        }

        float damage = dmg * damageMultiplier;


        Health = Math.Max(Health - damage, 0);

        return damage;
    }
}