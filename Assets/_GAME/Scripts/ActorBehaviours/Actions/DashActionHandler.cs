using UnityEngine;
using UnityEngine.AI;

public class DashActionHandler : PlayerActionHandler
{
    [SerializeField]
    float dashSpeed;

    [SerializeField]
    float dashTime;

    [SerializeField]
    float startDashTime;

    [SerializeField]
    Vector3 direction;

    bool isDashing;

    Rigidbody rb;
    NavMeshAgent nma;
    JumpActionHandler jah;

    void Start()
    {
        Debug.Log("Dash Action Handler engaged!");

        rb = GetComponent<Rigidbody>();
        nma = GetComponent<NavMeshAgent>();
        jah = GetComponent<JumpActionHandler>();

        initialize();
    }

    void startDash()
    {
        direction = nma.velocity;
        nma.enabled = false;
        jah.enabled = false;
        rb.isKinematic = false;
        isDashing = true;
    }

    public override void initialize()
    {
        isDashing = false;
        startDashTime = 0.5f;
        dashSpeed = 8;
        dashTime = startDashTime;
    }

    public override void reset()
    {
        direction = Vector3.zero;
        rb.velocity = Vector3.zero;
        dashTime = startDashTime;
        nma.enabled = true;
        jah.enabled = true;
        rb.isKinematic = true;
        isDashing = false;
    }

    void accelerate()
    {
        dashTime -= Time.deltaTime;
        float acceleration = (dashSpeed / startDashTime) * dashTime;
        rb.velocity = direction * acceleration;
    }

    void Update()
    {
        if(!isDashing && Stuff.GetButtonDown("Hotkey2")) {
            startDash();
        }
        
        if(isDashing) {
            if(dashTime <= 0) {
                reset();
            } else {
                accelerate();
            }
        }
    }
}