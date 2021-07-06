using UnityEngine;

public abstract class CharacterBehaviour : BaseEntity
{

    [SerializeField]
    protected float health;
    [SerializeField]
    protected float mana;
    [SerializeField]
    protected float cdr;
    [SerializeField]
    protected float castSpeed;
    [SerializeField]
    protected float attackSpeed;
    [SerializeField]
    protected float attackDamage;
    [SerializeField]
    protected float spellDamage;
    [SerializeField]
    protected float genericDamage;
    [SerializeField]
    protected float baseMovementSpeed;
    [SerializeField]
    protected float movementSpeedModifier;
    [SerializeField]
    protected float durationModifier;
    [SerializeField]
    protected float actionSpeed;
    [SerializeField]
    protected float range;

    public float GetActionSpeed()
    { return actionSpeed; }

    public float GetCdr()
    { return cdr; }

    public float GetCastSpeed()
    { return castSpeed; }
}
