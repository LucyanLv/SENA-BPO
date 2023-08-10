using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject panel;
    public Text questionText;
    public Button[] answerButtons;

    private bool isActive = false;
    private bool hasAnswered = false;

    public float reactivationDelay = 5f; // Delay before reactivating the panel

    public BaseDatos questionDatabase; // Reference to the Question Database scriptable object

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            Debug.Log("Entered Trigger Zone");
            isActive = true;
            panel.SetActive(true);
            LoadNextQuestion();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            isActive = false;
            panel.SetActive(false);
        }
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (!hasAnswered)
        {
            hasAnswered = true;
            CheckAnswer(answerIndex);
            StartCoroutine(ReactivatePanel());
        }
    }

    private IEnumerator ReactivatePanel()
    {
        yield return new WaitForSeconds(reactivationDelay);
        isActive = false;
        hasAnswered = false;
        panel.SetActive(false);
    }

    private void CheckAnswer(int answerIndex)
    {
        int correctAnswerIndex = questionDatabase.CurrentQuestion.CorrectAnswer;

        if (answerIndex == correctAnswerIndex)
        {
            Debug.Log("Correct Answer!");
        }
        else
        {
            Debug.Log("Incorrect Answer");
        }
    }

    private void LoadNextQuestion()
    {
        questionDatabase.MoveToNextQuestion(); // Move to the next question

        QuestionStruct currentQuestion = questionDatabase.CurrentQuestion;

        if (currentQuestion != null)
        {
            questionText.text = currentQuestion.Question;
            List<string> answers = currentQuestion.Answers;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                // Assign the option of response to the button text
                Text buttonText = answerButtons[i].GetComponentInChildren<Text>();
                if (buttonText != null && i < answers.Count)
                {
                    buttonText.text = answers[i];
                }
                else
                {
                    Debug.LogWarning("Text component not found in button " + i);
                }
            }
        }
        else
        {
            Debug.Log("No more questions!");
            panel.SetActive(false); // Deactivate the panel when all questions are answered
        }
    }
}