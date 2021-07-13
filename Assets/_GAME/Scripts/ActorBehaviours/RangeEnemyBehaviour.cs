using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBehaviour : EnemyBehaviour
{
    [SerializeField] private GameObject projectile;
    
    protected override void Update()
    {
        base.Update();
        
        if (isAttacking)
        {
            navAgent.speed = 0;
            navAgent.angularSpeed = 120;
        }
        else
        {
            navAgent.speed = 3.5f;
            navAgent.angularSpeed = 360000;
            FollowPlayer();
        }
    }

    public override IEnumerator Attack()
    {
        Debug.Log("RangeEnemy attacking...");
        isAttacking = true;
        
        yield return new WaitForSeconds(1);

        Instantiate(projectile, transform.position + transform.forward + (Vector3.up * 1.5f), transform.rotation);
        
        isAttacking = false;
    }
}
