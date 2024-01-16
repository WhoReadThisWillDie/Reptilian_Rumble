using System.Collections;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private float bounceDuration = 0.2f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;
    private Rigidbody2D rb2d;
    private bool isBouncingBack = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TakeHit()
    {
        if (EnemyHealth.GetIsHit() && !isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashCoroutine());
            StartCoroutine(BounceBack());
        }
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        isFlashing = false;
    }


private IEnumerator BounceBack()
{
    Vector3 originalPosition = transform.position;
    Vector3 targetPosition = originalPosition - transform.right * bounceForce; // Adjust direction and force as needed

    float elapsedTime = 0f;

    while (elapsedTime < bounceDuration)
    {
        // Calculate the new position based on the interpolation
        Vector3 newPosition = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / bounceDuration);

        // Move the enemy to the new position while handling collisions
        rb2d.MovePosition(newPosition);

        elapsedTime += Time.deltaTime;
        yield return null;
    }

    // Reset the sprite's position to avoid potential visual discrepancies
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
}

}
