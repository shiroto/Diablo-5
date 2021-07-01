using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : BaseAttack
{
    public override float BaseDamage => 10;
    public override DamageTypes DamageType => DamageTypes.Kinetic;
    public override float DamageInterval => -1;
    public override int DamageTimes => -1;
}