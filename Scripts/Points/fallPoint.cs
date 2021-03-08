using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPoint : MonoBehaviour
{

    private Animator manAnimator;
    private GameObject manObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Man"))
        {
            manAnimator = other.GetComponentInParent<Animator>();

            manAnimator.SetInteger("state", 4);
            manObject = other.transform.parent.gameObject;
            Destroy(manObject, 5);
        }
    }
}
