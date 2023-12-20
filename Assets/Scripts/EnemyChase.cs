using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private double chaseDistance;
    [SerializeField] private double attackDistance;
    [SerializeField] private Transform[] moveSpots;

    private Transform target;
    private bool isInAttackRange;
    private bool isInChaseRange;
    private double distanceToPlayer;
    private int randomSpot;
    private float patrolDirection = 1.0f;
    private float patrolTimer = 2.0f; // Time to patrol in one direction before changing
    private float timer;
    private Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = patrolTimer;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(transform.position, target.position);


        if (distanceToPlayer > attackDistance && distanceToPlayer < chaseDistance)
        {
            Chase();
        }

        else if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else
        {
            Patrol();
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
        FlipIfNeeded(target.position.x - transform.position.x);
    }

    private void Patrol()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            patrolDirection *= -1.0f; // Change direction
            timer = patrolTimer; // Reset the timer
        }

        Vector2 targetPosition = transform.position + Vector3.right * patrolDirection * patrolSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);
        animator.SetBool("isWalking", true);
        FlipIfNeeded(patrolDirection);
    }
    private void Attack()
    {
        animator.SetBool("isWalking", false);
        
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    private void FlipIfNeeded(float direction)
    {
        if ((direction > 0 && transform.localScale.x < 0) || (direction < 0 && transform.localScale.x > 0))
        {
            Flip();
        }
    }
}