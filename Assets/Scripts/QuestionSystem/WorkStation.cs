using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    public int NumeroMesa { get; set; }
    public StationState Estado { get; set; }
    // Otras propiedades relacionadas con la mesa

    public WorkStation()
    {
        Estado = StationState.Trabajando;
    }

    public void ChangeState(StationState nuevoEstado)
    {
        Estado = nuevoEstado;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Estado.Equals(StationState.HandRaised))
        {
            ChangeState(StationState.Preguntando);
            GameObject.FindObjectOfType<QuestionsManager>().launchQuestionPanel(collision);
        }
    }

}
