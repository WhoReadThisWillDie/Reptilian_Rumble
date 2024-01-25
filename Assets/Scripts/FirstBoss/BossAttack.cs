using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Head head;
    private Wave wave;
    private Animator animator;

    [SerializeField] private float delay;

    private int randomAttack;
    private bool isAttackBlocked = false;
    private readonly float stompDuration = 0.7f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        head = GetComponentInChildren<Head>();
        wave = GetComponentInChildren<Wave>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (isAttackBlocked)
        {
            return;
        }
        randomAttack = Random.Range(0, 2); // Boss will choose between 2 attacks

        switch (randomAttack)
        {
            case 0:
                animator.SetTrigger("BossStomps");
                StartCoroutine(StompAnimationDelay());
                break;
            case 1:
                head.PukeAttack();
                break;
        }



        isAttackBlocked = true;
        StartCoroutine(DelayBetweenAttacks());
    }

    private IEnumerator DelayBetweenAttacks()
    {
        yield return new WaitForSeconds(delay);
        isAttackBlocked = false;
    }

    private IEnumerator StompAnimationDelay()
    {
        yield return new WaitForSeconds(stompDuration);
        wave.WaveAttack();
    }
}
