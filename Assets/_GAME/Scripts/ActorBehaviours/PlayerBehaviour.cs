using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : BaseEntity
{
    [SerializeField] private LayerMask navigationLayer;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject destinationIndicator;
    
    ActionManager actionManager;
    DashActionHandler dashActionHandler;
    JumpActionHandler jumpActionHandler;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        actionManager = gameObject.AddComponent<ActionManager>() as ActionManager;
        actionManager.SetUser(gameObject);

        dashActionHandler = gameObject.AddComponent<DashActionHandler>();
        jumpActionHandler = gameObject.AddComponent<JumpActionHandler>();
    }
    
    private void watchNavAgent() {
        if(agent.enabled) {
            agent.speed = baseMovementSpeed * movementSpeedModifier;

            if (actionManager.IsCasting())
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }

    private void Update()
    {
        watchNavAgent();

        if (Stuff.GetButtonDown("Hotkey1"))
        {
            Vector3 temp = Stuff.Intersect();
            if (nma.enabled && !temp.Equals(Vector3.negativeInfinity))
            {
                agent.SetDestination(temp);
            }
        }
        if (Stuff.GetButtonDown("Hotkey3"))
        {
            if (actionManager.Use("Action2"))
            {
                //action was used
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            SetDestinationToMousePosition();
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
            Debug.Log($"Destiny is at {hit.point}");

            if (agent.SetDestination(hit.point))
            {
                destinationIndicator.transform.position = hit.point;
                destinationIndicator.SetActive(true);
            }
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

        Debug.Log($"Player Health {Health}");
        return damage;
    }
}