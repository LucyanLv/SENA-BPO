using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuControles;
    public GameObject menuSonido;
    public GameObject laPausa;
    public GameObject BotonP;
    public bool juegoP;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoP)
            {
                Reanudar();
            }
            else
            {
                pausa();
            }
        }
    }

    public void VolverAlMenu(string NombreDeEscena)
    {
        SceneManager.LoadScene(NombreDeEscena);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu_Sonido()
    {
        menuSonido.SetActive(true);
    }
    public void volver()
    {
        menuOpciones.SetActive(false);
    }
    public void volver1()
    {
        menuControles.SetActive(false);
        menuSonido.SetActive(false);
    }

    public void Opciones()
    {
        menuOpciones.SetActive(true);

    }

    public void Reanudar()
    {
        juegoP = false;
        laPausa.SetActive(false);
        BotonP.SetActive(true);
        Time.timeScale = 1f;
        menuOpciones.SetActive(false);
    }

    public void Controles()
    {
        menuControles.SetActive(true);
    }

    public void pausa()
    {
        juegoP = true;
        BotonP.SetActive(false);
        laPausa.SetActive(true);
        Time.timeScale = 0f;
    }
}
