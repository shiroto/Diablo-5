using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public abstract float BaseDamage { get; }
    public abstract DamageTypes DamageType { get; }
    public virtual float DamageInterval { get; }
    public virtual int DamageTimes { get; }
}