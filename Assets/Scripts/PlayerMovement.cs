using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        if (input.x != 0) 
        {
            animator.SetFloat("X", input.x);
            animator.SetBool("IsWalking", true);
        }
        else if (input.y != 0) 
        {
            animator.SetBool("IsWalking", true);
        }
        else if (input.x == 0 && input.y == 0)
        {
            animator.SetBool("IsWalking", false);
        } 
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }
}