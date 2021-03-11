    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    private Man manScript;
    private Animator manAnimator;
    private Rigidbody manRb;
    void Start() 
    {

    }

    private void Update()
    {
        if(manScript != null && manScript.isRotated == false)
        {
            manScript.isRotated = true;
            manScript.Look();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Man"))
        {
            manScript = other.GetComponentInParent<Man>();
            if (manScript.isGoingToJump == true)
            {
                manAnimator = other.GetComponentInParent<Animator>();
                manRb = other.GetComponentInParent<Rigidbody>();


                //karakter rampanın sonuna geldiğinde anlamsız zıplaması için ilk başta y position kilitli. Burada tekrardan açılıyor.
                manScript.isPatrolling = false;
                manScript.isGoingToJump= true;
                manRb.constraints = RigidbodyConstraints.None;
                manRb.freezeRotation = true;
                manScript.Look();
                manScript.Jump();
            }
        }
    }
}
