using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator animator;
    private float delay = 0.5f;
    private bool isAttackBlocked = false;

    void Start()
    {

    }

    void Update()
    {
        if (isAttackBlocked)
            return;
        animator.SetTrigger("attacking");
        isAttackBlocked = true;
    }
}
