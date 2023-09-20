using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivosTutorial : MonoBehaviour
{
    public Tutorial code;
    
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ObjetivoC"))
        {
            code.texto5();
            Debug.Log("entro");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
