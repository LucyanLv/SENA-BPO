using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    private float timer = 0f;
    public float duration = 0f;  // Duraci�n en segundos
    public float TiempoTranscurrido { get; private set; }
    [SerializeField] private int level;
    public StationState Estado { get; set; }
    [SerializeField] public int Level { get => level; set => level = value; }

    Transform emojis;
    // Otras propiedades relacionadas con la mesa
    private void Awake()
    {
        emojis = this.gameObject.transform.Find("Emojis");
    }
    public WorkStation()
    {
        Estado = StationState.Trabajando;
    }
    private void Update()
    {
        if (!Estado.Equals(StationState.Trabajando))
        {
            duration -= Time.deltaTime;
            Debug.Log(Mathf.Floor(duration));
            if (duration <= 0f)
            {
                
                if (Estado.Equals(StationState.Preguntando))
                {
                    FindObjectOfType<ShowQuiestionController>().NotAnswered();
                    ChangeState(StationState.DudaMal);
                }
                ChangeState(StationState.Trabajando);
            }
        }

        switch (Estado)
        {

            case StationState.HandRaised:
                if (Estado.Equals(StationState.HandRaised) && duration <= 0)
                {
                    ChangeState(StationState.Trabajando);
                }
                break;
            case StationState.DudaOk:
            case StationState.DudaMal:
                if (duration <= 0)
                {
                    Debug.Log("correct Answer ACA BAJO LO FELIZ O TISTE ");
                    emojis.Find("Emoji_OK").gameObject.SetActive(false);
                    emojis.Find("Emoji_Enojado").gameObject.SetActive(false);
                    ChangeState(StationState.Trabajando);
                }
                break;
            

        }
    }
    public void ChangeState(StationState nuevoEstado)
    {
        Debug.Log("new estadoooo");
        Estado = nuevoEstado;


        switch (Estado)
        {
            case StationState.HandRaised:
                Debug.Log("yo el asistente del " + gameObject.name + " y TENGO MI MANO LEVANTADA");
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(true);
                duration = (int)Estado; ;
                break;
            case StationState.Preguntando:
                Debug.Log("yo el asistente ESTOY PREGUNTANDO PRRO");
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(false);
                FindObjectOfType<QuestionsManager>().LaunchQuestionPanel();
                duration = (int)Estado - (level * 10) >= 30 ? (int)Estado - (level * 10) : 30;
                break;
            case StationState.DudaOk:
                Debug.Log("Correct Answer!");
                emojis.Find("Emoji_OK").gameObject.SetActive(true);
                duration = (int)Estado;
                break;
            case StationState.DudaMal:
                Debug.Log("Incorrect Answer");
                FindObjectOfType<EnergyController>().DecreaseEnergy(2);
                emojis.Find("Emoji_Enojado").gameObject.SetActive(true);
                duration = (int)Estado;
                break;
            case StationState.Trabajando:
            default:
                Debug.Log("trabajando ando ...................................... ");
                emojis.Find("Emoji_Pregunta").gameObject.SetActive(false);
                emojis.Find("Emoji_OK").gameObject.SetActive(false);
                emojis.Find("Emoji_Enojado").gameObject.SetActive(false);
                duration = 0;
                FindObjectOfType<QuestionsManager>().canAsk = true;
                break;
        }
    }
    private async void waitPerSeconds(int min, int max)
    {
        await Task.Delay(Random.Range(min, max));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Estado + "   ///   " + collision.tag);
        if (Estado.Equals(StationState.HandRaised) && collision.CompareTag("Player"))
        {
            ChangeState(StationState.Preguntando);
        }
        Debug.Log(Estado);
    }

}


/* YO COMO PUESTO DE TRABAJO 
 / LEVANTO MI MANO Y ESPERO A QUE INGRESEN 
    SI INGRESAN BAJO MI MANO Y PASO A PREGUNTAR
    SI NO INGRESAN TRAS UN TIEMPO DE 7 SEG BAJO LA MANO */
