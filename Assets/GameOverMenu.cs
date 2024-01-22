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

    void Update(){
        if(player.GetComponent<PlayerM>().Dead == true){
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.isPaused = true;
        }
    }

   
    public void RestartGame(){
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        player.GetComponent<PlayerM>().Dead = false;
        SceneManager.LoadScene(4);   
    }

}

    