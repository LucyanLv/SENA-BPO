using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLauncher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindObjectOfType<QuestionsLauncher>().launchQuestionPanel(collision);
    }
}
