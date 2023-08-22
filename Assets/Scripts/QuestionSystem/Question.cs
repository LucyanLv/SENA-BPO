using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class Question 
{
    public string questionText;
    public List<AnswerOption> answerOptions;

    public Question(){}

    public int getCorrectAnswerIndex()
    {
        return answerOptions.Where(obj => obj.isCorect)
            .Select(obj => obj.id).ToList()[0];  
    }

    public void sortAnswersRandomly()
    {
        int n = answerOptions.Count;
        System.Random rng = new System.Random();

        // Aplicar el algoritmo de Fisher-Yates
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AnswerOption value = answerOptions[k];
            answerOptions[k] = answerOptions[n];
            answerOptions[n] = value;
        }
    }
}
