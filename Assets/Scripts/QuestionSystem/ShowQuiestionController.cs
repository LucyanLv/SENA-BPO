using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ShowQuiestionController : MonoBehaviour
{
    public bool hasAnswered = false;
    [SerializeField] public GameObject questionCanvas;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerButtons;
    public Question question = new Question();


    [ContextMenu("HidePanel")]
    public void HideQuestionPanel()
    {
        if (!hasAnswered)
        {
            FindObjectOfType<EnergyController>().DecreaseEnergy(2);
        }
        questionCanvas.SetActive(false);
        GameObject.FindObjectOfType<Player_Mov>().canMove = true;
    }

    public void ShowQuestionPanel(Question question)
    {
        GameObject.FindObjectOfType<Player_Mov>().canMove = false;
        loadQuestion(question);
        questionCanvas.SetActive(true);

    }

    public void Answered(bool correct)
    {
        hasAnswered = true;
        StartCoroutine(Parpadear(correct));
    }
    public void NotAnswered()
    {
        hasAnswered = true;
        StartCoroutine(Parpadear(false));
    }



    private void loadQuestion(Question question)
    {
        char option = 'A';

        Debug.Log(question.questionText);

        questionText.text = question.questionText;
        for (int i = 0; i < question.answerOptions.Count; i++)
        {
            answerButtons[i].text = $"{option}) {question.answerOptions[i].answerText} **** {question.answerOptions[i].isCorect} ";
            option++;
        }

    }
    

    private IEnumerator Parpadear(bool correct)
    {
        Debug.Log("a parpadear");
        float tiempoTotal = 3f;  // Duración total del parpadeo (3 segundos)
        float tiempoPorColor = 0.5f;  // Tiempo por cada color (0.5 segundos)
        Color color1 = correct ? Color.green : Color.red;
        Color color2 = correct ? new Color(0, 255, 179) : new Color(255, 0, 72);
        while (tiempoTotal > 0f)
        {
            questionCanvas.GetComponent<Image>().color = color1;
            yield return new WaitForSeconds(tiempoPorColor);

            questionCanvas.GetComponent<Image>().color = color2;
            yield return new WaitForSeconds(tiempoPorColor);

            tiempoTotal -= tiempoPorColor * 2;
        }
        HideQuestionPanel();

    }

}
