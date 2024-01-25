using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Update = UnityEngine.PlayerLoop.Update;

public class MenuActivation : MonoBehaviour
{
    public GameObject tutorialPage1;
    public GameObject[] buttons;
    public GameObject[] menuPages;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLobby");
        if (Time.timeScale != 1f)
            {
                Time.timeScale = 1f;
            }
            PauseMenu.isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowTutorial()
    {
        tutorialPage1.SetActive(true);
        buttons[0].SetActive(true);
    }

    public void SkipSlide1()
    {
       menuPages[1].SetActive(true);
       buttons[1].SetActive(true);
    }
    public void SkipSlide2()
    {
        menuPages[2].SetActive(true);
        buttons[2].SetActive(true);

    }
    public void SkipSlide3()
    {
        menuPages[3].SetActive(true);
        buttons[3].SetActive(true);

    }
    public void SkipSlide4()
    {
        foreach (var page in menuPages)
        {
            page.SetActive(false);
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
            buttons[2].SetActive(false);
            buttons[3].SetActive(false);
        }    
    }
    
}
