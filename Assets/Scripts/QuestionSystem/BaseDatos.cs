using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "BaseDatos", menuName = "Create Question DataBase")]
public class BaseDatos : ScriptableObject
{
    [SerializeField] List<Question> questions = new List<Question>();
    [NonSerialized] private int currentQuestionIndex = 0;

    public Question CurrentQuestion
    {
        get
        {
            if (currentQuestionIndex < questions.Count)
                return questions[currentQuestionIndex];
            else
                return null;
        }
    }

    public List<Question> Questions { get => questions; set => questions = value; }

    public void MoveToNextQuestion()
    {
        currentQuestionIndex++;
    }
}
