using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private int damage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void WaveAttack()
    {
        animator.SetTrigger("WaveSpreads");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            collider.GetComponent<PlayerHit>().TakeHit();
        }
    }
}
