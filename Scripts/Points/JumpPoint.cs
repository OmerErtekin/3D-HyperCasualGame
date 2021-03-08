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
            manAnimator = other.GetComponentInParent<Animator>();
            manRb = other.GetComponentInParent<Rigidbody>();


            //karakter rampanýn sonuna geldiðinde anlamsýz zýplamasý için ilk baþta y position kilitli. Burada tekrardan açýlýyor.
            manScript.isPatrolling = false;
            manScript.readyToJump = true;
            manRb.constraints = RigidbodyConstraints.None;
            manRb.freezeRotation = true;
            manAnimator.SetInteger("state", 2);
        }
    }
}
