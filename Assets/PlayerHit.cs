using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
     [SerializeField] private float flashDuration;
    [SerializeField] private Color flashColor;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

     public void TakeHit()
    {
        if (PlayerHealth.GetIsHit() && !isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashCoroutineandSound());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FlashCoroutineandSound()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        isFlashing = false;
    }
}
