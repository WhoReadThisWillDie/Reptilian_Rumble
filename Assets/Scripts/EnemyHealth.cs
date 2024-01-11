using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private static bool isHit;
    [SerializeField] private float hitCooldownDuration = 2.0f;
    
    public void TakeDamage(int damage)
    {
        isHit = true;
        health -= damage;

        if (health <= 0)
        {
            Die();
            Spawner.SetRemainingEnemies(Spawner.GetRemainingEnemies() - 1);
        }

        StartCoroutine(HitCooldown());
    }


    // Death logic
    private void Die()
    {
        Destroy(this.gameObject);
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
