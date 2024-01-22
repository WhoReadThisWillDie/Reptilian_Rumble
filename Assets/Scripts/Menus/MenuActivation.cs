using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActivation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainLobby");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
