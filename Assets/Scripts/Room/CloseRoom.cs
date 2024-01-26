using System;
using System.Collections.Generic;
using UnityEngine;

public class CloseRoom : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<GameObject> enemies;

    private bool playerEntered = false;
    private bool roomCompleted = false;
    private bool doorsClosed = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player entered the room!");
            playerEntered = true;
            if (!doorsClosed)
            {
                ActivateDoors();
            }
        }
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (playerEntered && !roomCompleted && GetActiveEnemiesCount() == 0)
            {
                DeactivateDoors();
                doorsClosed = true;
                roomCompleted = true;
            }
        }
    }

    private void ActivateDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
    }

    private void DeactivateDoors()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }

    private int GetActiveEnemiesCount()
    {
        int count = 0;
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.GetComponent<EnemyMovement>().dead)
            {
                count++;
            }
        }
        return count;
    }
}
