using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    /* ColorMaterial index
     * 0 = blue
     * 1 = brown
     * 2 = green
     * 3 = red
     * 4 = yellow
     */
    public Text kontrolText;
    private Rigidbody ballRb;
    private Renderer ballRenderer;
    private Man manScript;
    private GameObject manToDestroy;
    public Material[] colorMaterials;
    public string currentColor;
    public string[] colors;
    private bool isColorSelected = false;
    public bool isThrowed = false;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        //Top yere düþerken kullanýcýnýn yakalammasýný kolaylaþtýrmak adýna drag ayarlarý
        if(ballRb.velocity.y>3 && isThrowed == true && ballRb.velocity.y<20)
        {
            if(isColorSelected == false)
            {
                SelectColor();
                isColorSelected = true;
            }
        }
        if(ballRb.velocity.y < -5)
        {
            ballRb.drag = 1;
        }
        else
        {
            ballRb.drag = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Topun renderer görüntüyü güzel göstermek için kayboluyor. Çoklu renkler için kontrol mekanizmasý yapýlacak
        if(collision.gameObject.CompareTag("Man"))
        {
            manToDestroy = collision.transform.parent.gameObject;
            manScript = collision.gameObject.GetComponentInParent<Man>();

            ballRenderer.enabled = false;
            Destroy(manToDestroy,1.5f);

            CheckWinState();
        }
        if(collision.gameObject.CompareTag("Platform") && isColorSelected == true)
        {
            kontrolText.text = "Kaybetti";
            Debug.Log("Kaybetti");
        }

    }

    void SelectColor()
    {
        int index = Random.Range(0, colors.Length);
        currentColor = colors[index];
        ballRenderer.material.color = colorMaterials[index].color;
    }

    public void CheckWinState()
    {
        if (manScript != null)
        {
            if (string.Equals(manScript.color,currentColor))
            {
                kontrolText.text = "Doðru eleman";
                Debug.Log("Doðru eleman");
            }
            else
            {
                kontrolText.text = "Yanlýþ Eleman";
                Debug.Log("Yanlýþ eleman");
            }
        }
    }
}
