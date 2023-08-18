using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class QuizController : MonoBehaviour
{
    public float timeBetweenPrints = 7.0f;
    public List<Question> questions = new List<Question>();

    private Question lastPrinted = null; 

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;

    Question randomQuestion = null;
    private void Start()
    {
        questions.Clear();
        questions.AddRange(GetComponent<QuestionsReader>().questions);
        StartCoroutine(PrintRandomTextWithDelay());
    }

    private IEnumerator PrintRandomTextWithDelay()
    {
        while (true)
        {
            randomQuestion = GetRandomQuestion();
            char option = 'A';
            if (randomQuestion != lastPrinted)
            {
                Debug.Log(randomQuestion.questionText);

                questionText.text = randomQuestion.questionText;

                for (int i = 0; i < randomQuestion.answerOptions.Count; i++)
                {
                   
                    answerTexts[i].text = option + " " + randomQuestion.answerOptions[i].answerText;
                    option++;
                }

                lastPrinted = randomQuestion;
            }

            yield return new WaitForSeconds(timeBetweenPrints);
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
        Debug.Log($"Respuesta ");
    }
}
