using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrollPoint : MonoBehaviour
{
    public Transform[] patrollPoints;
    private Man manScript;
    public int patrollIndex,newIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Man"))
        {
            manScript = other.GetComponentInParent<Man>();
            if (manScript.isGoingToJump == false)
            {
                SelectNewDestination();
            }
        }
    }

    void SelectNewDestination()
    {
        newIndex = Random.Range(0, patrollPoints.Length);
        if(newIndex == patrollIndex)
        {
            if(patrollIndex == patrollPoints.Length-1)
            {
                newIndex = 1;
            }
            else
            {
                newIndex++;
            }
        }
        manScript.patrollPoint = patrollPoints[newIndex];
    }
}
