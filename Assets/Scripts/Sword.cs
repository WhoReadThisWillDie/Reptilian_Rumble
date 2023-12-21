using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;

    private const float delay = 0.3f;
    private bool isAttackBlocked = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        // Manage animations and delays between attacks
        if (isAttackBlocked)
            return;
        animator.SetTrigger("Attack");
        isAttackBlocked = true;
        StartCoroutine(DelayAttack());

        // Detect enemies in attack range
        Collider2D[] enemiesToHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in enemiesToHit)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        isAttackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
