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
    public List<Question> relaxQuestions = new List<Question>();
    public List<Question> alreadyAnswered = new List<Question>();
    public List<Question> alreadySeen = new List<Question>();

    private Question lastPrinted = null;

    Question randomQuestion = new Question();
    GameObject advisor;

    [SerializeField] private int myLevel;

    [SerializeField] Final_Nivel final;
    public int conteoBien = 0;
    public int conteoMal = 0;

    private void Awake()
    {
        PlayerPrefs.SetInt("maxlvl", myLevel);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        List<Question> levelQuestions = GetComponent<QuestionsReader>().questions.Where(q => q.level <= myLevel && q.level > 0).ToList<Question>();
        relaxQuestions = GetComponent<QuestionsReader>().questions.Where(q => q.level == 0).ToList<Question>();
        questions.AddRange(levelQuestions);
        loadAviableQuestions();
    }

    private void loadAviableQuestions()
    {

        foreach (Question question in alreadyAnswered)
        {
            questions.Remove(question);
        }
        if (questions.Count > 0)
        {
            foreach (Question question in alreadySeen)
            {
                questions.Remove(question);
                relaxQuestions.Remove(question);
            }
        }
        else
        {
            questions.AddRange(alreadySeen);
            alreadySeen = new List<Question>();
        }
    }

    private void Update()
    {
        timeSinceLastHandRaise += canAsk ? Time.deltaTime : 0;

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
        advisor = workStationadvisors[Random.Range(0, workStationadvisors.Count)];
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
        loadAviableQuestions();
        Question random = lastPrinted;
        while (random == lastPrinted)
        {
            random = Random.Range(1, 100) > 20 ?
                questions[Random.Range(0, questions.Count)] :
                relaxQuestions[Random.Range(0, relaxQuestions.Count)];
        }
        random.sortAnswersRandomly();
        randomQuestion = random;
        return random;
    }

    public void CheckAnswer(int answerIndex)
    {
        string am = randomQuestion.level != 0 ? "normal" : "relax";

        if (randomQuestion.answerOptions[answerIndex].isCorect)
        {
            if (randomQuestion.level != 0)
            {
                questionsLeft--;
                alreadyAnswered.Add(randomQuestion);
                FindObjectOfType<MoneyController>().IncreaseMoney(1);
                conteoBien++;
                PlayerPrefs.SetInt($"correctaslvl{myLevel}", conteoBien);
                PlayerPrefs.Save();
            }
            FindObjectOfType<ShowQuiestionController>().Answered(true);
            advisor.GetComponent<WorkStation>().ChangeState(StationState.DudaOk);
            

        }
        else
        {
            if (randomQuestion.level != 0)
            {
                conteoMal++;
                FindObjectOfType<MoneyController>().DecreaseMoney(2);
            }
            FindObjectOfType<ShowQuiestionController>().Answered(false);
            advisor.GetComponent<WorkStation>().ChangeState(StationState.DudaMal);
            alreadySeen.Add(randomQuestion);
        }

        canAsk = false;
    }
}
