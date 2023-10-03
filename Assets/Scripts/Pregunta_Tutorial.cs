using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pregunta_Tutorial : MonoBehaviour
{
    public Button b1,b2,b3,b4;
    public GameObject textin,questionpanel;
    public Tutorial canvasDialogo;
    private string correcto;
    // Start is called before the first frame update
    void Start()
    {
        b1.onClick.AddListener(() => verificador(correcto));
        b2.onClick.AddListener(() => verificador("b"));
        b3.onClick.AddListener(() => verificador("c"));
        b4.onClick.AddListener(() => verificador("d"));
        
    }
    void verificador(string respuesta)
    {
        if(respuesta==correcto)
        {
            questionpanel.SetActive(false);
            canvasDialogo.panel.SetActive(true);
            canvasDialogo.texto12();
        }
        else
        {
           incorrect();
        }
        
    }
    public void incorrect()
    {
        canvasDialogo.panel.SetActive(true);
        questionpanel.SetActive(false);
        textin.SetActive(true);
    }
}
