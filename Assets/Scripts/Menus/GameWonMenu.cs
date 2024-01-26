using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameWonMenu;
    [SerializeField] private GameObject boss;
    public static bool bossDead;
    void Start()
    {
        gameWonMenu.SetActive(false);
    }

    void FixedUpdate()
    {
        if (boss.GetComponent<BossHealth>().health <= 0)
        {
            bossDead = true;
        }


        if(bossDead){
                gameWonMenu.SetActive(true);
                Time.timeScale = 0f;
                PauseMenu.isPaused = true;
        }
    }
}