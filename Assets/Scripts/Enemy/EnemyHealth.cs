using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private static bool isHit;
    [SerializeField] private float hitCooldownDuration;
    private Spawner spawner;
    public GameObject sword;
    public GameObject deadEnemy;
    private Rigidbody2D rb;
    private Renderer myRenderer;
    public EnemyMovement enemyMovement;

    private void Start()
    {
        deadEnemy.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        isHit = true;
        health -= damage;

        if (health <= 0)
        {
            Die();
            spawner.SetRemainingEnemies(spawner.GetRemainingEnemies() - 1);
        }

        StartCoroutine(HitCooldown());
    }


    // Death logic
    private void Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        sword.SetActive(false);
        deadEnemy.SetActive(true);
        myRenderer.enabled = false;
        enemyMovement.dead = true;
    }


    public static bool GetIsHit()
    {
        return isHit;
    }

    private IEnumerator HitCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(hitCooldownDuration);
            isHit = false; // Reset isHit to false after cooldown duration
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }
}
