using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class QuestionsLauncher : MonoBehaviour
{

    public GameObject professor;
    public GameObject questionCanvas;
    //public int hearts = 5;
    private bool isHandRaised = false;
    private float timeSinceLastHandRaise = 0f;

    private void Start()
    {
        Debug.Log("yo el asistente del " + transform.parent.gameObject.name + " y empezare a preguntar");
        StartCoroutine(HandRaiseCoroutine());

    }


    //("aca alzo mi mano y espero entre 10 a 15 segundos para que venga ");

    private void Update()
    {
        timeSinceLastHandRaise += Time.deltaTime;
    }

    private IEnumerator HandRaiseCoroutine()
    {
        while (true)
        {
            if (timeSinceLastHandRaise >= 10f)
            {
                isHandRaised = true;
                timeSinceLastHandRaise = 0f;
                Debug.Log("yo el asistente del " + transform.parent.gameObject.name + " y TENGO MI MANO LEVANTADA");
                // Play hand raise animation or change sprite
                // For simplicity, let's assume we're changing a sprite
                // GetComponent<SpriteRenderer>().sprite = raisedHandSprite;

                yield return new WaitForSeconds(Random.Range(15f, 30f)); // Wait for random time before next hand raise
                Debug.Log("ya baje mi manita " + transform.parent.gameObject.name);
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHandRaised)
        {
            if (Vector2.Distance(transform.position, professor.transform.position) < 1.5f)
            {
                questionCanvas.SetActive(true);
            }
            else
            {
                questionCanvas.SetActive(false);
            }
        }
    }

    // Call this method when the professor answers the question
    public void EvaluateAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            //score += 10;
            // Play happy animation or change sprite
            // GetComponent<SpriteRenderer>().sprite = happySprite;
        }
        else
        {
           // hearts--;
            // Play sad animation or change sprite
            // GetComponent<SpriteRenderer>().sprite = sadSprite;
        }

        isHandRaised = false;
    }
}


