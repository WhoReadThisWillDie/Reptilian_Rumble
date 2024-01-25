using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameWonMenu;
    [SerializeField] private GameObject boss;
    void Start()
    {
        gameWonMenu.SetActive(false);
    }

    void Update()
    {
        if (boss.GetComponent<BossHealth>().health <= 0)
        {
            if(!PauseMenu.isPaused){
                gameWonMenu.SetActive(true);
                Time.timeScale = 0f;
                PauseMenu.isPaused = true;
            }
        }
    }
}