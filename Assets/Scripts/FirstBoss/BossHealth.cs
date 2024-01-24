using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float hitCooldownDuration;
    public int health;
    public int maxHealth;
    private static bool isHit;
    private Rigidbody2D rb;
    private Renderer myRenderer;

    private void Start()
    {
        maxHealth = health;
        rb = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Boss took damage");
        isHit = true;
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        StartCoroutine(HitCooldown());
    }

    private void Die()
    {
        Debug.Log("Boss Dead");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
}
