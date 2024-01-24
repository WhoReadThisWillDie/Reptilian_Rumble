using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    [SerializeField] private int bounceForce;
    [SerializeField] private float bounceDuration;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeHit(Transform sender)
    {
        if (EnemyHealth.GetIsHit())
        {
            Bounce(sender);
        }
    }

    private void Bounce(Transform sender)
    {
        Vector2 direction = (transform.position - sender.position).normalized;
        rb2d.AddForce(direction * bounceForce, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(bounceDuration);
        rb2d.velocity = new Vector2(0, 0);
    }
}
