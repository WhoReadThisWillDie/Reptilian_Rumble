using System.Collections;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] private float flashDuration = 0.2f;
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] float bounceForce = 0.5f;
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
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
        float duration = 0.1f; // Adjust the duration of the bounce
        
        
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Calculate the bounce distance and direction
        Vector3 bounceOffset = targetPosition - originalPosition;

        // Apply the calculated bounce offset to the enemy's position
        transform.position += bounceOffset;

        // Reset the sprite's position to avoid potential visual discrepancies
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        
    }
}