using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject player;
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if (player.GetComponent<PlayerM>().dead == true)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;
        }
    }

    public void RestartGame()
    {
        GameWonMenu.bossDead = false;
        player.GetComponent<PlayerM>().dead = false;
        SceneManager.LoadScene(4);
        if(Time.timeScale != 1f){
            Time.timeScale = 1f;
            PauseMenu.isPaused = false;
        }
       
    }

}

