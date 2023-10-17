using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Nivel : MonoBehaviour
{
    [SerializeField] GameObject panelfinal;
    [SerializeField] GameObject panelmalo,puntos,panelpreguntas;
    [SerializeField] QuestionsManager manager;
    [SerializeField] Text puntajeBueno;
    [SerializeField] Text puntajeMalo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntajeBueno.text=""+ manager.conteoBien;
        puntajeMalo.text=""+ manager.conteoMal;
    }

    public void Nivelend()
    {
        Time.timeScale=0;
        panelpreguntas.SetActive(false);
        if(manager.conteoBien>manager.conteoMal)
        {
            panelfinal.SetActive(true);
            puntos.SetActive(true);
        }
        else
        {
            panelmalo.SetActive(true);
            puntos.SetActive(true);
           
        }

    }
}
