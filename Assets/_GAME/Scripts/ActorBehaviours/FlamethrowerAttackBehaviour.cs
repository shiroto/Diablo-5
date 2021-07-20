using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAttackBehaviour : MonoBehaviour
{
    [SerializeField] public bool isFiring;

    private ParticleSystem flames;
    private GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        flames = GetComponentInChildren<ParticleSystem>();
        hitbox = GameObject.Find("AttackArea");

        Initialize();
    }

    void Initialize()
    {
        isFiring = false;
        hitbox.SetActive(false);
    }

    public void StartFire()
    {
        isFiring = true;
        hitbox.SetActive(true);
        flames.Play();
    }

    public void StopFire()
    {
        isFiring = false;
        hitbox.SetActive(false);
        flames.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isFiring)
        {
            StartFire();
        }
        else if (Input.GetKeyUp(KeyCode.W) && isFiring)
        {
            StopFire();
        }
    }
}
