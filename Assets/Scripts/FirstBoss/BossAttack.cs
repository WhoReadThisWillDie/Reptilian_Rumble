using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private int chooseAttack;
    public Head bossHead;
    public Wave waveAttack;
    private Animator animator;
    private bool isAttackBlocked = false;
    public float delayBetweenAttacks;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(!PauseMenu.isPaused){
        BossChooseAttack();
        }
    }

    private void BossChooseAttack()
    {
        if (isAttackBlocked)
        {
            return;
        }
        chooseAttack = Random.Range(0, 2); // Boss will choose between 2 attacks

        if (chooseAttack == 0)
        {
            bossHead.PukeAttack();
            chooseAttack = 10;
        } else if (chooseAttack == 1)
        {
            animator.SetTrigger("BossStomps");
            waveAttack.WaveAttack();
            chooseAttack = 10;
        }
        isAttackBlocked = true;
        StartCoroutine(Wait(delayBetweenAttacks));
    }
    
    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttackBlocked = false;
    }
}
