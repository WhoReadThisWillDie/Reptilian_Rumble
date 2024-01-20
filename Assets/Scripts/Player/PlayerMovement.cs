using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 input;
    private Animator animator;
    [SerializeField] private float speed;
    public bool Dead = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Dead)
        {
            return;
        }
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        ManageAnimations();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = input * speed;
    }

    private void ManageAnimations()
    {
        if (input.x != 0 || input.y != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else if (input.x == 0 && input.y == 0)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}