using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivosTutorial : MonoBehaviour
{
    public Tutorial code;
    public Player_Mov code2;
    public GameObject panel;
    
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ObjetivoC"))
        {
            code.texto5();
            Debug.Log("entro");
        }
        if(other.CompareTag("PreguntaColl"))
        {
            panel.SetActive(true);
            code2.canMove=false;
        }
        
    }
    
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
