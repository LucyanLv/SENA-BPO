using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class QuestionsLauncher : MonoBehaviour
{
    [SerializeField] public GameObject questionCanvas;
    [SerializeField] private bool isHandRaised = false;
    [SerializeField] private bool canAsk = true;

    public Coroutine showingQuestion { get; private set; }
    private bool hideQuestion = false;

    [SerializeField] private float timeSinceLastHandRaise = 0f;
    [SerializeField] private float timeShowingQuiestion = 30f;

    public List<GameObject> advisors = new List<GameObject>();
    public List<Question> questions = new List<Question>();

    private Question lastPrinted = null;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;
    public TextMeshProUGUI[] answerButtons;

    Question randomQuestion = null;
    GameObject advisor;
    private bool hasAnswered = false;


    private void Start()
    {
        questions.AddRange(GetComponent<QuestionsReader>().questions);
        advisor = advisors[Random.Range(0, advisors.Count)];
        Debug.Log("yo el asistente del " + advisor.gameObject.name + " y empezare a preguntar");
        StartCoroutine(HandRaiseCoroutine());
    }

    private void Update()
    {
        timeSinceLastHandRaise += canAsk ? Time.deltaTime : 0;
    }

    private IEnumerator HandRaiseCoroutine()
    {
        while (canAsk)
        {
            if (timeSinceLastHandRaise >= Random.Range(5f, 10f))
            {
                isHandRaised = true;
                hideQuestion = false;
                timeSinceLastHandRaise = 0f;
                Debug.Log("yo el asistente del " + advisor.gameObject.name + " y TENGO MI MANO LEVANTADA");
                // Play hand raise animation or change sprite
                // For simplicity, let's assume we're changing a sprite
                // GetComponent<SpriteRenderer>().sprite = raisedHandSprite;
                advisor.transform.Find("Triangle").gameObject.SetActive(true);

                yield return new WaitForSeconds(Random.Range(5f, 10f)); // Wait for random time before next hand raise
                Debug.Log("ya baje mi manita " + advisor.gameObject.name);
                advisor.transform.Find("Triangle").gameObject.SetActive(false);

                advisor = advisors[Random.Range(0, advisors.Count)];
                isHandRaised = false;
                canAsk = false;

                yield return new WaitForSeconds(Random.Range(10f, 20f));
                Debug.Log("y bien juicioso espere pa volver a levantar la manita " + advisor.gameObject.name);
                canAsk = true;
                timeSinceLastHandRaise = 0;
            }

            yield return null;
        }
    }

    public void launchQuestionPanel(Collider2D collision)
    {

        if (collision.CompareTag("Player") && isHandRaised && canAsk)
        {
            canAsk = false;
            showingQuestion = StartCoroutine(ShowQuestion());

        }
    }

    private IEnumerator ShowQuestion()
    {
        showQuestionPanel();

        yield return new WaitForSeconds(timeShowingQuiestion);

        if (hideQuestion)
        {
            hideQuestionPanel();
            yield break;
        }

        if (!hasAnswered)
        {
            FindObjectOfType<Energia_player>().DecreaseEnergy(2);
        }
        hideQuestionPanel();
    }

    private void hideQuestionPanel()
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
                answerTexts[i].text = option + ") " + randomQuestion.answerOptions[i].answerText;
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
        if (randomQuestion.answerOptions[answerIndex].isCorect)
        {
            Debug.Log("Correct Answer!");
        }
        else
        {
            Debug.Log("Incorrect Answer");
            FindObjectOfType<Energia_player>().DecreaseEnergy(2);
            hideQuestion = true;
        }
        isHandRaised = false;
    }
}


