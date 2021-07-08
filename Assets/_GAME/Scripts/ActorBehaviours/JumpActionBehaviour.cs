using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpActionBehaviour : MonoBehaviour
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    Vector3 jumpVelocity;

    bool isJumping;

    Rigidbody rb;
    UnityEngine.AI.NavMeshAgent nma;
    DashActionBehaviour dab;

    void Start()
    {
        Debug.Log("Jump Action Handler engaged!");

        rb = GetComponent<Rigidbody>();
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
        dab = GetComponent<DashActionBehaviour>();

        initialize();
    }

    void OnCollisionStay()
    {
        reset();
    }

    void initialize()
    {
        isJumping = false;
        jumpForce = 5;
    }

    void reset()
    {
        isJumping = false;
        rb.isKinematic = true;
        nma.enabled = true;
        dab.enabled = true;
    }

    void jump()
    {
        isJumping = true;
        jumpVelocity = nma.velocity;
        nma.enabled = false;
        dab.enabled = false;
        rb.isKinematic = false;
        
        jumpVelocity.y = jumpForce;

        rb.AddForce(jumpVelocity, ForceMode.Impulse);
    }

    void Update()
    {
        if(!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
}
