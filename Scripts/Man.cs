using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Man : MonoBehaviour
{
    /*
     * isPatrolling false olursa navmesh kapanýyor. ReadyToJump true olduðunda jump buttonundan etkileniyor
     * isGoingToJump true olduðunda diðer patrolllerden etkilenmez. isRotated true olduðunda karakter zýplama rampasýnda topa döner
     */
    private NavMeshAgent agent;
    public bool isPatrolling = true,readyToJump = false, isGoingToJump = false,isRotated = false;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Look();
        }

    }


    public void Jump()
    {
        if (readyToJump == true)
        {
            manAnimator.SetInteger("state", 5);
            readyToJump = false;
        }
    }

    public void Look()
    {
        transform.LookAt(lookPosition);
    }
}
