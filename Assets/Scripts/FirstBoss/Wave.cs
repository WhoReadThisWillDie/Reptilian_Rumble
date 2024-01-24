using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int damage;
    private Animator animator;
    private bool isAttackBlocked = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void WaveAttack()
    {
        if (isAttackBlocked)
        {
            return;
        }
        isAttackBlocked = true;
        StartCoroutine(Wait(1f));
        animator.SetTrigger("WaveSpreads");
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttackBlocked = false;
    }
}
