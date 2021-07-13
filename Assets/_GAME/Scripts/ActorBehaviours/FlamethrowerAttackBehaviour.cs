using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAttackBehaviour : MonoBehaviour
{
    [SerializeField] private bool isFiring;

    private ParticleSystem flames;
    
    // Start is called before the first frame update
    void Start()
    {
        flames = GetComponentInChildren<ParticleSystem>();

        initialize();
    }

    void initialize()
    {
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isFiring)
        {
            isFiring = true;
            flames.Play();
        }
        else if(Input.GetKeyUp(KeyCode.W) && isFiring)
        {
            isFiring = false;
            flames.Stop();
        }
    }
}
