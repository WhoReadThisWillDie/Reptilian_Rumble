using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private int health;
    public GameObject sword;
    public GameObject deadPlayer;
    private Rigidbody2D rb;
    private Renderer myRenderer;
    public PlayerM playerM;
    private static bool isHit;
    
    public void Start()
    {
        deadPlayer.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetHealth(health);
        myRenderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        isHit = true;

        if (health <= 0)
        {
            Die();
        }
    }

    // Death logic
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        sword.SetActive(false);
        deadPlayer.SetActive(true);
        myRenderer.enabled = false;
        playerM.Dead = true;
    }

     public static bool GetIsHit()
    {
        return isHit;
    }
}