using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemyBehaviour : EnemyBehaviour
{
    
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
}
