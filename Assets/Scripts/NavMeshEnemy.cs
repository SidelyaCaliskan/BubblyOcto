using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Transform agentTransform;
    private float lastTransform;
    
    private NavMeshAgent agent;

    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        agentTransform = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    
    private void Update()
    {
        agent.SetDestination(target.position);
        if (agentTransform.position.x > lastTransform)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        
        lastTransform = agentTransform.position.x;
    }
}
