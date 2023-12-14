using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    private bool isFacingRight = true;
    [SerializeField] private float speed;

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

        ManageAnimations();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }

    private void ManageAnimations()
    {
        if ((input.x > 0 && !isFacingRight) || (input.x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
            animator.SetBool("IsWalking", true);
        }
        else if (input.x != 0 || input.y != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else if (input.x == 0 && input.y == 0)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}