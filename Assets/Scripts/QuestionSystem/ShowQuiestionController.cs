using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class ShowQuiestionController : MonoBehaviour
{
    public bool hasAnswered = false;
    [SerializeField] public GameObject questionCanvas;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerButtons;
    public Question question = new Question();
    public GameObject fondoVerde;
    public GameObject chulito;
    public GameObject fondoRojo;
    public GameObject cruz;
    public PlayableDirector playable;

    [ContextMenu("HidePanel")]
    public void HideQuestionPanel()
    {
        if (!hasAnswered)
        {
            FindObjectOfType<MoneyController>().DecreaseMoney(2);
        }
        questionCanvas.SetActive(false);
        GameObject.FindObjectOfType<Player_Mov>().canMove = true;
    }

    public void ShowQuestionPanel(Question question)
    {
        GameObject.FindObjectOfType<Player_Mov>().canMove = false;
        loadQuestion(question);
        FMODUnity.RuntimeManager.PlayOneShot("event:/OpenCanvas");
        questionCanvas.SetActive(true);

    }

    public void Answered(bool correct)
    {
        hasAnswered = true;
        if (correct)
        {
            HideQuestionPanel();
            FMODUnity.RuntimeManager.PlayOneShot("event:/RespondeBien");
            StartCoroutine(RespondioBien());
        }
        else
        {
            HideQuestionPanel();
            FMODUnity.RuntimeManager.PlayOneShot("event:/RespondeMal");
            StartCoroutine(RespondioMal());
        }
    }
    public void NotAnswered()
    {
        hasAnswered = true;
        StartCoroutine(RespondioMal());
    }

    private void loadQuestion(Question question)
    {
        char option = 'A';

        Debug.Log(question.questionText);

        questionText.text = question.questionText;
        for (int i = 0; i < question.answerOptions.Count; i++)
        {
            answerButtons[i].text = $"{option}) {question.answerOptions[i].answerText} {question.answerOptions[i].isCorect}";
          //  answerButtons[i].text = $"{option}) {question.answerOptions[i].answerText}";
            option++;
        }
    }
    private IEnumerator RespondioBien()
    {
        fondoVerde.SetActive(true);
        chulito.SetActive(true);
        yield return new WaitForSeconds(3);
        fondoVerde.SetActive(false);
        chulito.SetActive(false);
    }
    private IEnumerator RespondioMal()
    {
        fondoRojo.SetActive(true);
        cruz.SetActive(true);
        playable.Play();
        yield return new WaitForSeconds(3);
        fondoRojo.SetActive(false);
        cruz.SetActive(false);
    }
}
