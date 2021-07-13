using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttackAreaBehaviour : MonoBehaviour
{
    [SerializeField] private float damage;

    void OnTriggerStay(Collider other)
    {
        
        BaseEntity entity = other.gameObject.GetComponentInParent<BaseEntity>();

        if (entity != null)
        {
            entity.TakeDamage(damage * Time.deltaTime, DamageTypes.Elemental);
        }
    }
}
