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
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (!IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                animator.SetFloat("Movex", input.x);
                animator.SetFloat("Movey", input.y);
                var targetpos = transform.position;
                targetpos.x += input.x;
                targetpos.y += input.y;

                StartCoroutine(Move(targetpos));


            }
        }
        animator.SetBool("IsMoving", IsMoving);

    }
    IEnumerator Move(Vector3 targetpos)
    {
        IsMoving = true;
        while((targetpos - transform.position).sqrMagnitude> Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, speedPC * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;
        IsMoving = false;
    }
   
    //PC
   

   
}


