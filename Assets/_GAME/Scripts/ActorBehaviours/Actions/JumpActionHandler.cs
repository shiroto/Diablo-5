using UnityEngine;
using UnityEngine.AI;

public class JumpActionHandler : PlayerActionHandler
{
    [SerializeField]
    float jumpForce;

    [SerializeField]
    Vector3 jumpVelocity;

    bool isJumping;

    Rigidbody rb;
    NavMeshAgent nma;
    DashActionHandler dah;

    void Start()
    {
        Debug.Log("Jump Action Handler engaged!");

        rb = GetComponent<Rigidbody>();
        nma = GetComponent<NavMeshAgent>();
        dah = GetComponent<DashActionHandler>();

        initialize();
    }

    void OnCollisionStay()
    {
        reset();
    }

    public override void initialize()
    {
        isJumping = false;
        jumpForce = 3;
    }

    public override void reset()
    {
        isJumping = false;
        rb.isKinematic = true;
        nma.enabled = true;
        dah.enabled = true;
    }

    void jump()
    {
        isJumping = true;
        jumpVelocity = nma.velocity;
        nma.enabled = false;
        dah.enabled = false;
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