using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private int maxLifetime;
    
    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds(maxLifetime));
        GetComponent<Rigidbody>().AddRelativeForce((Vector3.up * 0.1f) + Vector3.forward * power);
    }

    public IEnumerator DestroyAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
