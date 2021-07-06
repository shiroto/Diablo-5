using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    private int tookDamage = 0;
    private float timeInCollision = 0;
    [SerializeField] private BaseEntity damageableEntity;
    private BaseAttack attack;
    
    private void Damage()
    {
        tookDamage++;
        
        if (damageableEntity != null)
        {
            damageableEntity.TakeDamage(attack.BaseDamage, attack.DamageType);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        timeInCollision = 0;
        attack = other.gameObject.GetComponent<BaseAttack>();
        
        if (attack == null) return;

        if (attack.DamageInterval < 0)
        {
            Damage();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (attack == null) return;
        if (attack.DamageInterval < 0) return;
        if (attack.DamageTimes >= 0 && tookDamage >= attack.DamageTimes) return;
        
        timeInCollision += Time.fixedDeltaTime;
        
        if (timeInCollision >= attack.DamageInterval)
        {
            timeInCollision = 0;
            Damage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (attack == null) return;
        attack = null;
        timeInCollision = 0;
    }
}
