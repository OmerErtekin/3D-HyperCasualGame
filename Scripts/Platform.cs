using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platform : MonoBehaviour
{
    private Ball ballScript;
    private Rigidbody platformRb;
    private Rigidbody ballRb;
    public float throwPower;
    public bool isThrowing = false;
    void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        ballRb = GameObject.Find("Ball").GetComponent<Rigidbody>();
        ballScript = GameObject.Find("Ball").GetComponent<Ball>();

    }

    void FixedUpdate()
    {
        //Kullanýcýdan alýnan inputa göre yay ayarlanacak.
        if(isThrowing == true)
        {
            ballRb.AddForce(0, -throwPower, 0);
            platformRb.AddForce(0, -throwPower, 0);
        }
        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ThrowTheBall());
        }
    }


    IEnumerator ThrowTheBall()
    {
        isThrowing = true;
        yield return new WaitForSeconds(2.5f);
        isThrowing = false;
        yield return new WaitForSeconds(1f);
        ballScript.isThrowed = true;
    }


}
