using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    [SerializeField] private int bounceForce;
    [SerializeField] private float bounceDuration;
    public Sounds playSounds;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeHit(Transform sender)
    {
        if (BossHealth.GetIsHit())
        {
            Bounce(sender);
            playSounds.BossHitSound();
        }
    }

    private void Bounce(Transform sender)
    {
        Vector2 direction = (transform.position - sender.position).normalized;
        rb2d.AddForce(direction * bounceForce * rb2d.mass, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(bounceDuration);
        rb2d.velocity = new Vector2(0, 0);
    }
}
