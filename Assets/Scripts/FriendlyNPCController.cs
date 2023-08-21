using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class FriendlyNPCController : MonoBehaviour
{
    public float interactionRange = 3f; 
    private Transform player;

     //[SerializeField] private GameObject dialogueMark;
   //  [SerializeField] private GameObject dialoguePanel;
    // [SerializeField] private TMP_Text dialogueText;
   //  [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
 //   private bool didDialogueStart;
  //  private int lineIndex;

  //  private float typingTime = 0.05f;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= interactionRange && Input.GetButtonDown("Fire1"))
            {
                /*
                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueline();

                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }

             // dialogueMark.SetActive(true);

                */

                    Debug.Log("¡Hola! ¿Cómo estás?");
            }
        }
    }
    /*
   void StartDialogue()
    {
        // didDialogueStart = true;
        // dialoguePanel.SetActive(true);
        //  dialogueMark.SetActive(false);

        lineIndex = 0;
        StartCoroutine(Showline());

    }
 private void NextDialogueline()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {

            StartCoroutine(Showline());


        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);

        }
           
                   
}


    private IEnumerator Showline()
    {
        // dialogueText.text..string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);


        }


    }




   
    
     
        



    */



}
