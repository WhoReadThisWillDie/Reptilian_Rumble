using System;
using UnityEngine;

public class CloseRoom : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player entered the room!");
            door.SetActive(true);
        }
    }

    private void Update()
    {
        if (Spawner.GetRemainingEnemies() == 0)
        {
            door.SetActive(false);
            Debug.Log("no enemies left");
        }
    }
}