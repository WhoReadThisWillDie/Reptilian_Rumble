using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Sword : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private LayerMask attackLayerMask;
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
        Collider2D[] objectsToHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayerMask);

        // Detect which layer is hitted
        foreach (Collider2D collider in objectsToHit)
        {
            switch (LayerMask.LayerToName(collider.gameObject.layer))
            {
                // Player layer
                case "Player":
                    collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                    collider.GetComponent<PlayerHit>().TakeHit();
                    break;
                // Enemy layer
                case "Enemy":
                    collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                    collider.GetComponent<EnemyHit>().TakeHit(GetComponentInParent<Transform>());
                    break;
                //Boss layer
                case "Boss":
                    collider.GetComponent<BossHealth>().TakeDamage(damage);
                    collider.GetComponent<BossHit>().TakeHit(GetComponentInParent<Transform>());
                    break;
            }
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
