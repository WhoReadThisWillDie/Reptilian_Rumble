using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotActiveInLobby : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            gameObject.SetActive(true);
        }
    }
}
