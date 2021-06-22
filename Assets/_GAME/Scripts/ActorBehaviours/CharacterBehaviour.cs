using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    protected float health;
    protected float mana;
    protected float cdr;
    protected float castSpeed;
    protected float attackSpeed;
    protected float attackDamage;
    protected float spellDamage;
    protected float genericDamage;
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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
