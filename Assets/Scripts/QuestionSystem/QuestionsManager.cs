using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionsManager : MonoBehaviour
{
    [SerializeField] public bool canAsk = true;
    [SerializeField] private bool isAsking = false;

    [SerializeField] private float timeSinceLastHandRaise = 0f;
    [SerializeField] private int timeShowingQuiestion = 30;

    [SerializeField] private float timeBetwenHandsRaise = 60f;

    [SerializeField] private int questionsLeft = 10;

    public List<GameObject> workStationadvisors = new List<GameObject>();
    public List<Question> questions = new List<Question>();

    private Question lastPrinted = null;

    Question randomQuestion = new Question();
    GameObject advisor;

    [SerializeField] private int myLevel;

    [SerializeField]  Final_Nivel final;
    public  int conteoBien=0;
    public int conteoMal=0;

    private void Start()
    {
        List<Question> levelQuestions = GetComponent<QuestionsReader>().questions.Where(q => q.level <= myLevel).ToList<Question>();
        questions.AddRange(levelQuestions);
        
    }

    private void Update()
    {
        timeSinceLastHandRaise += canAsk ? Time.deltaTime : 0;
        Debug.Log("timeSinceLastHandRaise " + Mathf.Floor(timeSinceLastHandRaise));
        
        if (timeSinceLastHandRaise >= Random.Range(4f, 8f) && canAsk && questionsLeft > 0)
        {
            LaunchQuestion();
        }
        else if (questionsLeft <= 0)
        {
            Debug.Log("NIVEL TERMINADOOOOOOOO WIIIIIIIIIII ");
            final.FinalizacionNivel();
            canAsk = false;
        }
    }

    private void LaunchQuestion()
    {
        Debug.Log("////////////// inicio a preguntar ///////////////");
        advisor = workStationadvisors[Random.Range(0, workStationadvisors.Count)];
        Debug.Log("yo el asistente del " + advisor.gameObject.name + " y empezare a preguntar");
        if (canAsk)
        {
            isAsking = true;
            canAsk = false;
            advisor.GetComponent<WorkStation>().ChangeState(StationState.HandRaised);
        }
        timeSinceLastHandRaise = 0;
    }

    public void LaunchQuestionPanel()
    {
        if (isAsking && !canAsk)
        {
            FindObjectOfType<ShowQuiestionController>().ShowQuestionPanel(GetRandomQuestion());
        }
    }

    private Question GetRandomQuestion()
    {
        Question random = lastPrinted;
        while (random == lastPrinted)
        {
            random = questions[Random.Range(0, questions.Count)];
        }
        random.sortAnswersRandomly();
        randomQuestion = random;
        return random;
    }

    public void CheckAnswer(int answerIndex)
    {
        Debug.Log($"respondio {answerIndex} que es {randomQuestion.answerOptions[answerIndex].answerText}");

        if (randomQuestion.answerOptions[answerIndex].isCorect)
        {
            questionsLeft--;
            conteoBien++;
            FindObjectOfType<ShowQuiestionController>().Answered(true);
            advisor.GetComponent<WorkStation>().ChangeState(StationState.DudaOk);
        }
        else
        {
            conteoMal++;
            FindObjectOfType<ShowQuiestionController>().Answered(false);
            advisor.GetComponent<WorkStation>().ChangeState(StationState.DudaMal);
        }
        canAsk = false;
    }
}
