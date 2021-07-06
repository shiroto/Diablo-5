using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : BaseEntity
{

    [SerializeField]
    protected float health;
    protected float mana;
    protected float cdr;
    protected float castSpeed;
    protected float baseMovementSpeed;
    protected float movementSpeedModifier;
    protected float durationModifier;
    protected float actionSpeed;
    protected float range;

    public float GetActionSpeed()
    { return actionSpeed; }

    public float GetCdr()
    { return cdr; }

    public float GetCastSpeed()
    { return castSpeed; }
}
