using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    private float timer = 0f;
    public float duration = 0f;  // Duración en segundos
    public float TiempoTranscurrido { get; private set; }
    [SerializeField] private int level;
    public StationState Estado { get; set; }
    [SerializeField] public int Level { get => level; set => level = value; }

    // Otras propiedades relacionadas con la mesa

    public WorkStation()
    {
        Estado = StationState.Trabajando;
    }
    private void Update()
    {
        if (Estado.Equals(StationState.HandRaised))
        {
            duration = (int)Estado;

        }
    }
    public void ChangeState(StationState nuevoEstado)
    {
        Debug.Log("new estadoooo");
        Estado = nuevoEstado;
        TiempoTranscurrido = 0f;

        Transform emojis = this.gameObject.transform.Find("Emojis");
        switch (Estado)
        {
            case StationState.HandRaised:
                Debug.Log("yo el asistente del " + gameObject.name + " y TENGO MI MANO LEVANTADA");
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(true);
                duration = (int)Estado / (level); ;
                break;
            case StationState.Preguntando:
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(false);
                GameObject.FindObjectOfType<QuestionsManager>().launchQuestionPanel();
                duration = (int)Estado / (level * 0.13f);
                break;
            case StationState.DudaOk:
                Debug.Log("Correct Answer!");
                emojis.Find("Emoji_OK").gameObject.SetActive(true);
                waitPerSeconds(4, 6);
                Debug.Log("correct Answer ACA BAJO LO FELIZ");
                emojis.Find("Emoji_OK").gameObject.SetActive(false);
                Estado = StationState.Trabajando;
                break;
            case StationState.DudaMal:
                Debug.Log("Incorrect Answer");
                FindObjectOfType<Energia_player>().DecreaseEnergy(2);
                emojis.Find("Emoji_Enojado").gameObject.SetActive(true);
                waitPerSeconds(4, 6);
                Debug.Log("Incorrect Answer ACA BAJO LO ENOJADO");
                emojis.Find("Emoji_Enojado").gameObject.SetActive(false);
                Estado = StationState.Trabajando;
                //Caritas.desactivar
                break;
            case StationState.Trabajando:
            default:
                Debug.Log("trabajando ando ...................................... ");
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(false);
                emojis.Find("Emoji_OK").gameObject.SetActive(false);
                emojis.Find("Emoji_Enojado").gameObject.SetActive(false);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Estado.Equals(StationState.HandRaised) && collision.CompareTag("Player"))
        {
            ChangeState(StationState.Preguntando);
        }
    }

    private async void waitPerSeconds(int min, int max)
    {
        await Task.Delay(Random.Range(min, max));
    }

}


/*public class Mesa
{



    public void ActualizarTiempoEnEstado(float deltaTime)
    {
        TiempoTranscurridoEnEstado += deltaTime;

        // Si el tiempo en este estado supera la duración, cambia al siguiente estado
        if (TiempoTranscurridoEnEstado >= (float)EstadoActual)
        {
            // Cambiar al siguiente estado (podrías implementar lógica para determinar el próximo estado)
            EstadoMesa siguienteEstado = (EstadoMesa)(((int)EstadoActual + 1) % Enum.GetValues(typeof(EstadoMesa)).Length);
            CambiarEstado(siguienteEstado);
        }
    }
}*/
