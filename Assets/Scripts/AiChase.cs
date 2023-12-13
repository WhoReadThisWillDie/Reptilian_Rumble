using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private double chaseDistance;
    [SerializeField] private double attackDistance;
    [SerializeField] private Transform[] moveSpots;

    private Transform target;
    private bool isInAttackRange;
    private bool isInChaseRange;
    private double distanceBetweenPandE;
    private int randomSpot;
    private float patrolDirection = 1.0f;
    private float patrolTimer = 2.0f; // Time to patrol in one direction before changing
    private float timer;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = patrolTimer;
    }

    void FixedUpdate()
    {
        distanceBetweenPandE = Vector2.Distance(transform.position, target.position);


        if (distanceBetweenPandE > attackDistance && distanceBetweenPandE < chaseDistance)
        {
            Chase();
        }

        else if (distanceBetweenPandE <= attackDistance)
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
    }
    private void Attack()
    {

    }
}