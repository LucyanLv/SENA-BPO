using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fin_juego : MonoBehaviour

{
    [SerializeField] GameObject[] shispa;
    [SerializeField] GameObject menu;
    private int aleatorio;

    
    void Start()
    {
        menu.SetActive(false);
        shispa = GameObject.FindGameObjectsWithTag("Shispitas");
        StartCoroutine(Boton());
        
        // Desactiva todas las "shipitas" al inicio.
        foreach (var shipita in shispa)
        {
            shipita.SetActive(false);
        }
    }

    void Update()
    {
        // Activa una "shipita" de manera aleatoria.
        aleatorio = Random.Range(0, shispa.Length);
        shispa[aleatorio].SetActive(true);

        // Desactiva la "shipita" anterior.
        int anterior = (aleatorio - 1 + shispa.Length) % shispa.Length;
        shispa[anterior].SetActive(false);
    }
    IEnumerator Boton()
    {
        
        yield return new WaitForSeconds(4f);
        menu.SetActive(true);

    }
}
