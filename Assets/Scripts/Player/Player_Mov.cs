using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("PC")]

    public float speedPC;
    // public float desx, desy;
    private Vector2 input;
    // private Vector2 direccionMov;
    private bool IsMoving;
    private Animator animator;
    [SerializeField]
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
    /*IEnumerator Move(Vector3 targetpos)
    {
        IsMoving = true;
        while((targetpos - transform.position).sqrMagnitude> Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, speedPC * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;
        IsMoving = false;
    }*/

    //PC

    public void DecreaseSpeed(int speedDecrease)
    {
        speedPC-= speedDecrease;
    }

}


