using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SelectMan : MonoBehaviour
{
    private Camera cam;
    private Man manScript;
    private NavMeshAgent manAgent;
    public Transform startToJumpPoint;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.touchCount !=1)
        {
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Man")
        {
            manAgent = hit.transform.GetComponentInParent<NavMeshAgent>();
            manScript = hit.transform.GetComponentInParent<Man>();

            //StartToJump doðru olunca karakter diðer patroll noktalarýndan etkilenmiyor.
            manAgent.speed = 25;
            manAgent.angularSpeed = 1080;
            manScript.patrollPoint = startToJumpPoint;
            manScript.isGoingToJump = true;
        }
    }
}
