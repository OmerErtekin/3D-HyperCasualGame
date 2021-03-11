using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TorusPoint : MonoBehaviour
{
    public int pointType;
    private Torus torusScript;
    private Renderer torusRenderer;
    public SelectMan selectScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Man"))
        {
            selectScript.RestartScene();
        }

        if(other.CompareTag("Torus"))
        {
            torusRenderer = other.GetComponent<Renderer>();
            torusScript = other.GetComponent<Torus>();
            if(pointType == 1)
            {
                torusScript.direction = 1;
                if(torusScript.touchedCount >0)
                {
                    torusScript.CheckWinState();
                }

                torusScript.touchedCount = 0;
                torusScript.currentColor = "";
                torusScript.currentColor2 = "";
                torusScript.touchedColor = "";


                for (int i = 0;i<10;i++)
                {
                    torusRenderer.materials[i].color = Color.white;
                }
            }
            if (pointType == -1)
            {
                torusScript.direction = -1;
                if (torusScript.manCount > 0)
                {
                    torusScript.SelectColor();
                }
            }
        }
    }
}
