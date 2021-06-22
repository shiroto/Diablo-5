using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellHandler : ActionHandler
{
    public override float GetActionTime()
    {
        if (user.GetComponent<CharacterBehaviour>().GetCastSpeed() > 0)
        {
            return baseActionTime / user.GetComponent<CharacterBehaviour>().GetCastSpeed();
        }
        else
        {
            return baseActionTime;
        }
    }

    public override float GetBaseActionTime()
    { return baseActionTime; }

    public override float GetBaseCoolDown()
    { return baseCooldown; }

    public override bool Instantiate()
    { return false; }
}