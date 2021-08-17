using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashActionBehaviour : MonoBehaviour
{
    [SerializeField] 
    private float dashSpeed;
    
    [SerializeField] 
    float dashTime;

    [SerializeField]
    float startDashTime;

    [SerializeField]
    Vector3 direction;
    
    public bool isDashing;

    Rigidbody rb;
    UnityEngine.AI.NavMeshAgent nma;
    JumpActionBehaviour jab;

    void Start()
    {
        Debug.Log("Dash Action Handler engaged!");

        rb = GetComponent<Rigidbody>();
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
        jab = GetComponent<JumpActionBehaviour>();

        initialize();
    }

    public void startDash()
    {
        direction = nma.velocity;
        nma.enabled = false;
        jab.enabled = false;
        rb.isKinematic = false;
        isDashing = true;
    }

    void initialize()
    {
        isDashing = false;
        startDashTime = 0.5f;
        dashSpeed = 4;
        dashTime = startDashTime;
    }

    void reset()
    {
        direction = Vector3.zero;
        rb.velocity = Vector3.zero;
        dashTime = startDashTime;
        nma.enabled = true;
        jab.enabled = true;
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
        
        
        if(!isDashing && Input.GetMouseButtonDown(1)) {
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
