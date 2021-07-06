using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        BaseEntity entity = other.gameObject.GetComponent<BaseEntity>();
        if (entity != null)
        {
            Debug.Log("Is this where it happens?");
            Debug.Log(enemy);
            StartCoroutine(enemy.Attack());
        }
    }
}
