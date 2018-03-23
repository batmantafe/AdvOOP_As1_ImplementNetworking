using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent nav;
    
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NavTarget();
    }

    void NavTarget()
    {
        if (player != null)
        {
            // Set destination to Player's position
            nav.SetDestination(player.position);
        }
    }
}
