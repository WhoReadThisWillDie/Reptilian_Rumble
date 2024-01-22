using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private double chaseDistance;
    [SerializeField] private double attackDistance;

    private Rigidbody2D rb2d;
    private NavMeshAgent agent;
    private Transform target;
    private Animator animator;
    private Sword sword;

    private double distanceToPlayer;
    private float patrolDirection = 1.0f;
    private float patrolTimer = 2.0f; // Time to patrol in one direction before changing
    private float timer;
    private bool isAttackBlocked = true;
    private float delayBeforeAttack = 0.5f;
    internal bool dead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = patrolTimer;
        animator = GetComponent<Animator>();
        sword = GetComponentInChildren<Sword>();
    }

    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            if (dead)
            {
                return;
            }

            distanceToPlayer = Vector2.Distance(transform.position, target.position);

            if (distanceToPlayer > attackDistance && distanceToPlayer < chaseDistance)
            {
                agent.enabled = true;
                Chase();
                isAttackBlocked = true; // reset delay before attack if player is outside the attack distance
            }
            else if (distanceToPlayer <= attackDistance)
            {
                Attack();
                agent.enabled = false;
            }
            else
            {
                Patrol();
                isAttackBlocked = true; // reset delay before attack if player is outside the attack distance
            }
        }
    }

    private void Chase()
    {
        agent.SetDestination(new Vector3(target.position.x, target.position.y, transform.position.z));
        animator.SetBool("isWalking", true);
    }

    private void Patrol()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            patrolDirection *= -1.0f; // Change direction
            timer = patrolTimer; // Reset the timer
        }

        Vector3 targetPosition = transform.position + Vector3.right * patrolDirection * patrolSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);
        animator.SetBool("isWalking", true);
    }

    private void Attack()
    {
        animator.SetBool("isWalking", false);
        StartCoroutine(DelayBeforeAttack(delayBeforeAttack));

        if (isAttackBlocked)
        {
            return;
        }

        sword.Attack();
    }

    private IEnumerator DelayBeforeAttack(float delayBeforeAttack)
    {
        yield return new WaitForSeconds(delayBeforeAttack);
        isAttackBlocked = false;
    }
}