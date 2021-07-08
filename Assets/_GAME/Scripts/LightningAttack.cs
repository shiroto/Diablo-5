using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    [SerializeField] private Collider attackArea;
    [SerializeField] private ParticleSystem vfx;
    
    void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        attackArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        attackArea.enabled = false;
        Destroy(gameObject);
    }
    
}
