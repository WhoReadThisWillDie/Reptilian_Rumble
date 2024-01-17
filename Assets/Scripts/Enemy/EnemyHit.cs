using System.Collections;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private float flashDuration;
    [SerializeField] private Color flashColor;
    [SerializeField] private int bounceForce;
    [SerializeField] private float bounceDuration;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;
    private Rigidbody2D rb2d;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeHit(Transform sender)
    {
        if (EnemyHealth.GetIsHit() && !isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashCoroutine());
            Bounce(sender);
        }
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        isFlashing = false;
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
