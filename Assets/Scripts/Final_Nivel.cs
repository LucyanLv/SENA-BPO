using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UsuarioGuardado;

public class Final_Nivel : MonoBehaviour
{
    [SerializeField] GameObject panelfinal;
    [SerializeField] GameObject panelmalo,puntos,panelpreguntas,cajaPuntaje,canvas;
    [SerializeField] QuestionsManager manager;
    [SerializeField] Player_Mov player;
    [SerializeField] Text puntajeBueno;
    [SerializeField] Text puntajeMalo;
    [SerializeField] Text usernameText;

    private void Start()
    {
        usernameText.text = PlayerData.Username;
    }

    // Update is called once per frame
    void Update()
    {
        puntajeBueno.text=""+ manager.conteoBien;
        puntajeMalo.text=""+ manager.conteoMal;
    }

    public void FinalizacionNivel()
    {
        player.canMove=false;
        panelpreguntas.SetActive(false);
        canvas.SetActive(false);
        if(manager.conteoBien>manager.conteoMal)
        {
            panelfinal.SetActive(true);
            puntos.SetActive(true);
            cajaPuntaje.SetActive(true);

        }
        else
        {
            panelmalo.SetActive(true);
            puntos.SetActive(true);
            cajaPuntaje.SetActive(true);
           
        }

    }
    public void VolverAlMenu(string NombreDeEscena)
    {
       SceneManager.LoadScene(NombreDeEscena);
         canvas.SetActive(true);
    }
    public void SiguienteNivel(/*string NombreDeNivel*/)
    {
//       SceneManager.LoadScene(NombreDeNivel);

        int indiceActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceActual + 1);
    }
    public void Reiniciar()
    {
       Time.timeScale=1f;
       canvas.SetActive(true);
       panelfinal.SetActive(false);
       panelmalo.SetActive(false);
       puntos.SetActive(false);
       cajaPuntaje.SetActive(false);
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
