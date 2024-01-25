using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private float waitToEnd;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject talkingUI;
    public GameObject pressE;
  

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            pressE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            pressE.SetActive(false);
        }
    }

    public void ShowTalk()
    {
        talkingUI.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitToEnd);
        talkingUI.SetActive(false);
    }
    
}
