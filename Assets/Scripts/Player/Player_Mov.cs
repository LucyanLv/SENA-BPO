using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [Header("PC")]
    public float speedPC;
    public float velocidadInicio = 10f;
    private Vector2 input;
    private bool IsMoving;
    private bool cambioVelocidad = false;
    public bool canMove = true;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (Time.time < 40f)
        {
            CambiarVelocidadInicial();
        }
        else if (!cambioVelocidad)
        {
            CambiarVelocidadNormal();
        }

        if (input != Vector2.zero && canMove)
        {
            animator.SetFloat("Movex", input.x);
            animator.SetFloat("Movey", input.y);
            IsMoving = true;
            rb.velocity = new Vector2(input.x * speedPC, input.y * speedPC);
        }
        else
        {
            rb.velocity = Vector2.zero;
            IsMoving = false;
        }

        animator.SetBool("IsMoving", IsMoving);
    }

    private void CambiarVelocidadInicial()
    {
        speedPC = velocidadInicio;
    }

    private void CambiarVelocidadNormal()
    {
        speedPC = 7;
        cambioVelocidad = true;
    }

    public void DecreaseSpeed(int speedDecrease)
    {
        speedPC -= speedDecrease;
    }
}
