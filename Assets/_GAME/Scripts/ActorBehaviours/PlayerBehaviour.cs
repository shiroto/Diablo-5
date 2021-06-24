using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : CharacterBehaviour
{
    private ActionManager actionManager;

    [SerializeField]
    private NavMeshAgent agent;

    public Vector3 jump;
    public float jumpForce = 4.0f;
    
    public bool isGrounded;
    public bool isDashing;

    Rigidbody rb;
    NavMeshAgent nma;

    private void AddAction(ActionHandler ah)
    {
        actionManager.AddAction(ah);
    }

    private void FixedUpdate()
    {
    }

    void OnCollisionStay() {
        enableNavigator();
        isGrounded = true;
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

        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //
        actionManager = gameObject.AddComponent<ActionManager>() as ActionManager;
        actionManager.SetUser(gameObject);

        //initialize player data

        //initialize comet data
        //
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

    private void disableNavigator() {
        rb.isKinematic = false;
        nma.enabled = false;
    }

    private void enableNavigator() {
        rb.isKinematic = true;
        nma.enabled = true;
    }

    private void performDash() {
        Vector3 movementVelocity = nma.velocity;
        movementVelocity.y = 0;

        disableNavigator();

        rb.AddForce(movementVelocity * 10.0f, ForceMode.Impulse);
    }

    private void watchDashVelocity() {
        if(isDashing && rb.velocity == Vector3.negativeInfinity) {
            enableNavigator();
        }
    }

    private void watchJumpAction() {
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing) {
            Vector3 movementVelocity = nma.velocity;

            disableNavigator();

            isGrounded = false;

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            rb.AddForce(movementVelocity * 50, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        watchNavAgent();
        watchJumpAction();

        if (Stuff.GetButtonDown("Hotkey1"))
        {
            Vector3 temp = Stuff.Intersect();
            if (nma.enabled && !temp.Equals(Vector3.negativeInfinity))
            {
                agent.SetDestination(temp);
            }
        }
        if (Stuff.GetButtonDown("Hotkey2"))
        {
            performDash();
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