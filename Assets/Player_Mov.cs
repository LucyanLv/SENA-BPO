using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("PC")]

    public float speedPC;
    public float desx, desy;
    private Vector2 direccionMov;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void Update()
    { 
        
          
    }

    private void FixedUpdate()
    {
        movementCapture();
        movement();
        
    }

    //PC
    void movementCapture()
    {
        desx = Input.GetAxisRaw("Horizontal");
        desy = Input.GetAxisRaw("Vertical");
        direccionMov = new Vector2(desx, desy);
    }

    void movement()
    {
        rb.velocity = new Vector2(x: direccionMov.x * speedPC, y: direccionMov.y * speedPC) * Time.deltaTime;
    }

}


