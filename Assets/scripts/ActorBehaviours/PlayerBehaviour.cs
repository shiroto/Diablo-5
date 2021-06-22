using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : CharacterBehaviour
{
    private ActionManager actionManager;

    [SerializeField]
    private NavMeshAgent agent;

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

        //
        actionManager = gameObject.AddComponent<ActionManager>() as ActionManager;
        actionManager.SetUser(gameObject);

        //initialize player data

        //initialize comet data
        //
    }

    // Update is called once per frame
    private void Update()
    {
        //set agents speed every frame
        agent.speed = baseMovementSpeed * movementSpeedModifier;

        if (actionManager.IsCasting())
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

        //handle input
        if (Stuff.GetButtonDown("Hotkey1"))
        {
            Vector3 temp = Stuff.Intersect();
            if (!temp.Equals(Vector3.negativeInfinity))
            {
                agent.SetDestination(temp);
            }
        }
        if (Stuff.GetButtonDown("Hotkey2"))
        {
            if (actionManager.Use("Action1"))
            {
                //action was used
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