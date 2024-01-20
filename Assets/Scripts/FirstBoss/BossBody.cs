using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private double chaseDistance;
    [SerializeField] private double attackDistance;
    
    private double distanceToPlayer;
    private Rigidbody2D rb;
    private Transform target;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool isFreezed;
    public Transform playerObject; // Assign the PlayerObject in the Unity Editor
    
   
    void Start()
    {
        isFreezed = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
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
            animator.SetBool("BossIsWalking", false);
        }
    }
    
    private void Chase(bool isFreezed)
    {
        if (isFreezed)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool("BossIsWalking", true);
        }
    }
    

}
