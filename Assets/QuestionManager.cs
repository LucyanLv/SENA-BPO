using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject panel;
    public Text questionText;
    public Button[] answerButtons;

    private bool hasEncounteredObject = false;

    private string[] questions = { "¿Cuál es la capital de Francia?", "¿En qué año comenzó la Segunda Guerra Mundial?", "¿Cuántos planetas hay en nuestro sistema solar?" };
    private string[][] answers = {
        new string[] { "Madrid", "París", "Berlín", "Londres" },
        new string[] { "1939", "1945", "1942", "1918" },
        new string[] { "7", "8", "9", "10" }
    };
    private int currentQuestionIndex = 0;

    private void Start()
    {
        panel.SetActive(false);
        DisplayQuestion();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasEncounteredObject)
        {
            hasEncounteredObject = true;
            panel.SetActive(true);
        }
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (currentQuestionIndex < questions.Length)
        {
            CheckAnswer(answerIndex);
            currentQuestionIndex++;
            DisplayQuestion();
        }
        else
        {
            Debug.Log("No more questions!");
           
        }
    }

    private void CheckAnswer(int answerIndex)
    {
        string correctAnswer = answers[currentQuestionIndex][0];
        string selectedAnswer = answers[currentQuestionIndex][answerIndex];

        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("¡Respuesta correcta!");
     
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
       
        }
    }

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = answers[currentQuestionIndex][i];
            }
        }
        else
        {
            Debug.Log("No more questions!");
         
        }
    }
}
