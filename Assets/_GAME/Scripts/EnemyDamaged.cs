using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fireball fireball = other.GetComponent<Fireball>();
        if (fireball != null)
        {
            Debug.Log("DAMAGED " + fireball.Damage);
        }
    }
}