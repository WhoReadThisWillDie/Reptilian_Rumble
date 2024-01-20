using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    private Animator animator;
    public Transform player; // Reference to the player object
    public float rotationSpeed; // Rotation speed as needed

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    

    void Update()
    {
        // Calculate the direction vector from the object to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the rotation angle in degrees
        float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Smoothly rotate the object towards the player
        float currentAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetAngle, ref rotationSpeed, 0.1f);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

        // Flip the object when it rotates more than 180 degrees
        if (Mathf.Abs(currentAngle) < 90f && Mathf.Abs(currentAngle) > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Mathf.Abs(currentAngle) < 360f && Mathf.Abs(currentAngle) > 270f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else 
        {
            transform.localScale = new Vector3(-1f, -1f, 1f);
        }
    }
    
    

    public void PukeAttack()
    {
        animator.SetTrigger("IsPuking");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
