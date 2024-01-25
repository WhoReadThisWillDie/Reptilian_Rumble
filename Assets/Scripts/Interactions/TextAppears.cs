using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppears : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public AudioSource audioSource;
    void Start()
    {
        textcomponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            audioSource.Play();
        }
    }
}
