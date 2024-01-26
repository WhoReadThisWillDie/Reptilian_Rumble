using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBody : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private double chaseDistance;
    [SerializeField] private double attackDistance;

    private double distanceToPlayer;
    private Rigidbody2D rb;
    private Transform target;
    private Animator animator;
    private NavMeshAgent agent;
    public bool isFreezed;
    public Transform playerObject; // Assign the PlayerObject in the Unity Editor


    void Start()
    {
        isFreezed = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (playerObject != null)
            {
                // Check if the player is to the left or right of the bossObject
                bool playerIsLeft = playerObject.position.x < transform.position.x;

                // Flip the bossObject accordingly
                if (playerIsLeft && transform.localScale.x > 0)
                {
                    // If the player is on the left and the boss is not already flipped, flip the bossObject
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (!playerIsLeft && transform.localScale.x < 0)
                {
                    // If the player is on the right and the boss is flipped, reset the scale to face right
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

            rb.velocity = new Vector2(0, 0);
            // Move the object in the x-direction

            distanceToPlayer = Vector2.Distance(transform.position, target.position);
            if (distanceToPlayer > attackDistance && distanceToPlayer < chaseDistance)
            {
                Chase(isFreezed);
            }
            else
            {
                agent.SetDestination(transform.position);
                animator.SetBool("BossIsWalking", false);
            }
        }
    }

    private void Chase(bool isFreezed)
    {
        if (!isFreezed)
        {
            agent.SetDestination(new Vector3(target.position.x, target.position.y, transform.position.z));
            animator.SetBool("BossIsWalking", true);
        }
    }


}
