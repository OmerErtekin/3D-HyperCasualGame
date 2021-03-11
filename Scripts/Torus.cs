using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class Torus : MonoBehaviour
{
    private Man manScript;
    private Collider manCollider;
    private GameObject manToDestroy;
    private Renderer torusRenderer;
    public SelectMan selectScript;
    public Material[] colorMaterials;
    public string currentColor;
    public string currentColor2;
    public string touchedColor;
    public string[] colors;
    private bool isLevelPassed = false;
    public bool isColorSelected = false;
    private int index;
    public float levelSpeed;
    public int colorCount, manCount, touchedCount = 0, direction = 1;

    void Start()
    {
        torusRenderer = GetComponent<Renderer>();
    }


    private void FixedUpdate()
    {
        Move();
        if(manCount == 0 && isLevelPassed == false)
        {
            isLevelPassed = true;
            selectScript.NextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Topun renderer görüntüyü güzel göstermek için kayboluyor. Çoklu renkler için kontrol mekanizmasý yapýlacak
        if (other.gameObject.CompareTag("Man"))
        {
            manCollider = other.gameObject.GetComponentInChildren<Collider>();
            manToDestroy = other.gameObject;
            manScript = other.gameObject.GetComponentInParent<Man>();

            touchedColor += manScript.color;
            touchedCount++;

            manCollider.enabled = false;
            Destroy(manToDestroy, 1.5f);

            if (touchedCount == colorCount)
            {
                CheckWinState();
            }
            else if (touchedCount > colorCount)
            {
                selectScript.RestartScene();
                Debug.Log("Fazladan dokunuþ. Kaybetti");
                
                // kontrolText.text = "Fazladan dokunuþ. Kaybetti";
            }
        }
    }

    public void SelectColor()
    {
        index = Random.Range(0, colors.Length - 1);


        currentColor = colors[index];
        if (colorCount == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                torusRenderer.materials[i].color = colorMaterials[index].color;
            }
        }
        else if (colorCount == 2)
        {
            currentColor2 = colors[index + 1];
            for (int i = 0; i < 5; i++)
            {
                torusRenderer.materials[i].color = colorMaterials[index].color;
            }
            for (int i = 5; i < 10; i++)
            {
                torusRenderer.materials[i].color = colorMaterials[index+1].color;
            }
        }
    }

    public void CheckWinState()
    {

        if (colorCount == 1)
        {
            if (string.Equals(touchedColor, currentColor))
            {
                //kontrolText.text = "Doðru eleman";
                DeleteFromArray(index);
                Debug.Log("Doðru eleman");

                touchedCount = 0;
                touchedColor = "";
                manCount--;
            }
            else
            {
                // kontrolText.text = "Yanlýþ Eleman";
                selectScript.RestartScene();
                Debug.Log("Yanlýþ eleman");
            }
        }
        {
            if (colorCount == 2)
            {
                if (string.Equals(touchedColor, currentColor + currentColor2) || string.Equals(touchedColor, currentColor2 + currentColor))
                {
                   
                    Debug.Log("2li doðru");
                    //kontrolText.text = "2li doðru eleman";
                    
                    DeleteFromArray(index);
                    //listenin boyu 1 azaldýðý için sýradaki index ayný olur.
                    DeleteFromArray(index);
                    
                    manCount -= 2;
                    touchedCount = 0;
                    touchedColor = "";
                }
                else
                {
                    //kontrolText.text = "2li yanlýþ eleman";
                    selectScript.RestartScene();
                }
            }
        }
    }

    private void Move()
    {
        if (direction == 1)
        {
            transform.position += new Vector3(0, 3 * direction * levelSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(0, direction * levelSpeed * Time.deltaTime, 0);
        }
    }
    public void DeleteFromArray(int index)
    {
        Material[] newMatList = new Material[colorMaterials.Length - 1];
        string[] newColorList = new string[colors.Length - 1];
        for (int i = 0; i < colorMaterials.Length - 1; i++)
        {
            if (i < index)
            {
                newMatList[i] = colorMaterials[i];
            }
            else
            {
                newMatList[i] = colorMaterials[i + 1];
            }
        }
        for (int j = 0; j < colors.Length - 1; j++)
        {
            if (j < index)
            {
                newColorList[j] = colors[j];
            }
            else
            {
                newColorList[j] = colors[j + 1];
            }
        }

        colorMaterials = newMatList;
        colors = newColorList;

    }


}
