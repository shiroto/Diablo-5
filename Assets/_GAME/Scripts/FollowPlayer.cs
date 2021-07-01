using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;


    void FixedUpdate()
    {
        // navMeshAgent.SetDestination(player.position);
    }
}