using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    public virtual float Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }
    public virtual float MaxHealth
    {
        get { return maxHealth; }
        protected set { maxHealth = value; }
    }
    public virtual float Health
    {
        get { return health; }
        protected set { health = value; }
    }

    public abstract float TakeDamage(float dmg, DamageTypes type);

    private void OnDrawGizmos()
    {
        // Handles.Label(transform.position, $"Health: {Health}\n");
    }
}