using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTransition : MonoBehaviour
{
    private float waitTime = 33f;
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        if(!PauseMenu.isPaused){ 
            if (Input.anyKeyDown) 
            {
                SceneManager.LoadScene("MainMenu");
            }    
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }

    
 
}
