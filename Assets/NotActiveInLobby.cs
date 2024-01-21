using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotActiveInLobby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex == 4){
        gameObject.SetActive(true);
       }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
