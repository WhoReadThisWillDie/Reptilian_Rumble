using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Sword : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private float delay;

    private bool isAttackBlocked = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        // Manage animations and delays between attacks
        if (isAttackBlocked)
        {
            return;
        }

        animator.SetTrigger("Attack");
        isAttackBlocked = true;
        StartCoroutine(DelayAttack());

        // Detect enemies in attack range
        Collider2D[] objectsToHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, hitLayer);

        // Detect which layer is hitted
        switch (hitLayer.value)
        {
            // Player layer
            case 8:
                objectsToHit[0].GetComponent<PlayerHealth>().TakeDamage(damage);
                break;
            // Enemy layer
            case 64:
                foreach (Collider2D enemy in objectsToHit)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
                    enemy.GetComponent<EnemyHit>().TakeHit(GetComponentInParent<Transform>()); // pass the player transform
                }
                break;
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
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
