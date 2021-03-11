using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Man : MonoBehaviour
{

    private NavMeshAgent agent;
    // isPatrolling dogru oldugunda karakter kosar. isGoingToJump dogru oldugunda karakter diger patrollPointlerden etkilenmez.
    public bool isPatrolling = true, isGoingToJump = false;
    public string color;
    private Animator manAnimator;
    public Transform patrollPoint,lookPosition;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        manAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPatrolling == true && agent != null)
        {
            manAnimator.SetInteger("state", 1);
            agent.enabled = true;
            agent.SetDestination(patrollPoint.position);
        }
        else
        {
            agent.enabled = false;
        }


    }


    public void Jump()
    {
        
        manAnimator.SetInteger("state", 5);
        
    }

    public void Look()
    {
        transform.LookAt(lookPosition);
    }
}
