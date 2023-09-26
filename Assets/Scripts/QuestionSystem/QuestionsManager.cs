using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class QuestionsManager : MonoBehaviour
{
    [SerializeField] public GameObject questionCanvas;
    [SerializeField] private bool isHandRaised = false;
    [SerializeField] private bool canAsk = true;

    public Coroutine showingQuestion { get; private set; }
    private bool hideQuestion = false;

    [SerializeField] private float timeSinceLastHandRaise = 0f;
    [SerializeField] private int timeShowingQuiestion = 30;

    [SerializeField] private float timeBetwenHandsRaise = 60f;

    [SerializeField] private int quiestionsLeft = 10;

    public List<GameObject> workStationadvisors = new List<GameObject>();
    public List<Question> questions = new List<Question>();

    private Question lastPrinted = null;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerButtons;

    Question randomQuestion = null;
    GameObject advisor;
    private bool hasAnswered = false;
    [SerializeField] private int myLevel;

    private void Awake()
    {
        Debug.Log("aca se awakea el manager");
    }
    private void Start()
    {
        List<Question> levelQuestions = GetComponent<QuestionsReader>().questions.Where(q => q.level <= myLevel).ToList<Question>();
        questions.AddRange(levelQuestions);
        LaunchQuestion();
    }

    private void Update()
    {
        timeSinceLastHandRaise += canAsk ? Time.deltaTime : 0;

        if (timeSinceLastHandRaise >= Random.Range(35f, 50f) && canAsk && quiestionsLeft > 0)
        {
            LaunchQuestion();
        }
    }

    private void LaunchQuestion()
    {
        Debug.Log("////////////// inicio a preguntar ///////////////");
        advisor = workStationadvisors[Random.Range(0, workStationadvisors.Count)];
        Debug.Log("yo el asistente del " + advisor.gameObject.name + " y empezare a preguntar");
        if (canAsk)
        {
            isHandRaised = true;
            hideQuestion = false;
            advisor.GetComponent<WorkStation>().ChangeState(StationState.HandRaised);


            /* advisor = workStationadvisors[Random.Range(0, workStationadvisors.Count)];
             isHandRaised = false;
             canAsk = false;


             Debug.Log("y bien juicioso espere pa volver a levantar la manita " + advisor.gameObject.name);
             canAsk = true;
             timeSinceLastHandRaise = 0;*/
        }


    }

    public void launchQuestionPanel()
    {

        if (isHandRaised && canAsk)
        {
            canAsk = false;
            ShowQuestion();

        }
    }

    private async void ShowQuestion()
    {
        showQuestionPanel();

        await Task.Delay(timeShowingQuiestion * 1000);

        if (hideQuestion)
        {
            hideQuestionPanel();
        }

        if (!hasAnswered)
        {
            FindObjectOfType<Energia_player>().DecreaseEnergy(2);
        }
        hideQuestionPanel();
    }

    public void hideQuestionPanel()
    {
        questionCanvas.SetActive(false);
        GameObject.FindObjectOfType<Player_Mov>().canMove = true;
        canAsk = true;
        timeSinceLastHandRaise = 0;
    }

    private void showQuestionPanel()
    {
        GameObject.FindObjectOfType<Player_Mov>().canMove = false;
        loadQuestion();
        questionCanvas.SetActive(true);
    }

    private void loadQuestion()
    {
        randomQuestion = GetRandomQuestion();
        randomQuestion.sortAnswersRandomly();

        char option = 'A';
        if (randomQuestion != lastPrinted)
        {
            Debug.Log(randomQuestion.questionText);

            questionText.text = randomQuestion.questionText;
            for (int i = 0; i < randomQuestion.answerOptions.Count; i++)
            {
                answerButtons[i].text = option + ") " + randomQuestion.answerOptions[i].answerText;
                option++;
            }
            lastPrinted = randomQuestion;
        }
    }

    private Question GetRandomQuestion()
    {
        Question random = lastPrinted;
        while (random == lastPrinted)
        {
            random = questions[Random.Range(0, questions.Count)];
        }
        return random;
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (!hasAnswered)
        {
            hasAnswered = true;
            CheckAnswer(answerIndex);
        }
    }

    private void CheckAnswer(int answerIndex)
    {
        Debug.Log($"respondio {answerIndex} que es {randomQuestion.answerOptions[answerIndex].answerText}");
        hideQuestion = true;
        timeShowingQuiestion = 5;
        hideQuestionPanel();

        if (randomQuestion.answerOptions[answerIndex].isCorect)
        {

            advisor.gameObject.GetComponent<WorkStation>().ChangeState(StationState.DudaOk);
        }
        else
        {
            advisor.gameObject.GetComponent<WorkStation>().ChangeState(StationState.DudaMal);

        }
        isHandRaised = false;

    }

}


