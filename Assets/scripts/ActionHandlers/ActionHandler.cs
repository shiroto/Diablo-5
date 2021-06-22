using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionHandler : MonoBehaviour
{
    protected float baseActionTime;

    protected float baseCooldown;

    protected float baseDamage;

    protected float baseDuration;

    protected float baseManaCost;

    protected float currentCooldown;

    protected GameObject user;

    public abstract float GetActionTime();

    public abstract float GetBaseActionTime();

    public abstract float GetBaseCoolDown();

    public float GetBaseDamage()
    { return baseDamage; }

    public float GetBaseDuration()
    { return baseDuration; }

    public float GetBaseManaCost()
    { return baseManaCost; }

    public float GetCurrentCooldown()
    { return currentCooldown; }

    public abstract bool Instantiate();

    public void SetUser(GameObject u)
    { user = u; }

    protected IEnumerator Cooldown()
    {
        currentCooldown = baseCooldown * (1 - user.GetComponent<CharacterBehaviour>().GetCdr());

        int segments = 10; //number of checks of current cdr performed. higher value = more updates = more accuracy for HUD;
        float segmentLength = currentCooldown / 10;
        for (int i = 0; i < segments; i++)
        {
            yield return new WaitForSeconds(segmentLength);
            currentCooldown -= segmentLength;
        }
        currentCooldown = 0;
    }

    //rotates user towards new rotation. use when casting spells
    protected IEnumerator RotateUser(Quaternion finalRot)
    {
        Quaternion startRot = Quaternion.LookRotation(transform.forward);
        float timestep = 0.02f, timeCount = 0;

        //hard exit after half a second
        while (transform.rotation != finalRot && timeCount <= 0.5)
        {
            transform.rotation = Quaternion.Slerp(startRot, finalRot, timeCount * 8);
            yield return new WaitForSeconds(timestep);
            timeCount = timeCount + timestep;
        }
    }
}