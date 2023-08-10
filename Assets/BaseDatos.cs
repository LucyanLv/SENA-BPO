using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "BaseDatos", menuName = "Create Question DataBase")]
public class BaseDatos : ScriptableObject
{
    [SerializeField] List<QuestionStruct> questions = new List<QuestionStruct>();
    [SerializeField] List<int> questionsShowed = new List<int>();

    [NonSerialized] private int currentQuestionIndex = 0;

    public QuestionStruct CurrentQuestion
    {
        get
        {
            if (currentQuestionIndex < questions.Count)
                return questions[currentQuestionIndex];
            else
                return null;
        }
    }

    public List<QuestionStruct> Questions { get => questions; set => questions = value; }
    public List<int> QuestionsShowed { get => questionsShowed; set => questionsShowed = value; }

    public void MoveToNextQuestion()
    {
        currentQuestionIndex++;
    }
}

[Serializable]
public class QuestionStruct
{
    [SerializeField] string question;
    [SerializeField] List<string> answers;
    [SerializeField] int correctAnswer;

    public string Question { get => question; set => question = value; }
    public List<string> Answers { get => answers; set => answers = value; }
    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
}