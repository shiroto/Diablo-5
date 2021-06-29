using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : CharacterBehaviour
{
    ActionManager actionManager;
    DashActionHandler dashActionHandler;
    JumpActionHandler jumpActionHandler;

    [SerializeField]
    NavMeshAgent agent;

    Rigidbody rb;
    NavMeshAgent nma;

    private void AddAction(ActionHandler ah)
    {
        actionManager.AddAction(ah);
    }

    private void FixedUpdate()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
        health = 20;
        mana = 10;
        baseMovementSpeed = 5;
        movementSpeedModifier = 1;
        cdr = 0.3f;
        range = 2;

        rb = GetComponent<Rigidbody>();
        nma = GetComponent<NavMeshAgent>();

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

    // Update is called once per frame
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
    }
}