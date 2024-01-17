using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private static bool isHit;
    [SerializeField] private float hitCooldownDuration;
    private Spawner spawner;
    
    public void TakeDamage(int damage)
    {
        isHit = true;
        health -= damage;
        int remainingEnemies;

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
        Destroy(gameObject);
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
