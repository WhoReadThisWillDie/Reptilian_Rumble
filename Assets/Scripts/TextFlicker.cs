using System.Collections;
using TMPro;
using UnityEngine;

public class FlickeringText : MonoBehaviour
{
    private TextMeshProUGUI flickerText;

    void Start()
    {
        flickerText = GetComponent<TextMeshProUGUI>();
        flickerText.color = new Color(flickerText.color.r, flickerText.color.g, flickerText.color.b, 0f); 
        StartCoroutine(FlickerTextCoroutine());
    }

    IEnumerator FlickerTextCoroutine()
    {
        float initialDelay = 3f; // Delay before the text starts appearing
        float flickerDuration = 5f;
        float flickerInterval = 0.1f; // Adjust as needed

        Color startColor = flickerText.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f); 

        yield return new WaitForSeconds(initialDelay);

        float timer = 0f;

        while (timer < flickerDuration)
        {
            float alpha = Mathf.Sin(timer / flickerDuration * Mathf.PI); 
            flickerText.color = Color.Lerp(startColor, endColor, alpha);
            yield return new WaitForSeconds(flickerInterval);
            timer += flickerInterval;
        }

        
        flickerText.enabled = false;

        
    }
}
