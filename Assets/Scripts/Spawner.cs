using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDistance = 0.5f;

    [SerializeField] private int quantityToSpawn;

    [SerializeField] private GameObject[] enemyPrefabs;

    private List<Vector2> spawnedPositions = new List<Vector2>();
    private static int remainingEnemies;

    private void Start()
    {
        for (int i = 0; i < quantityToSpawn; i++)
        {
            Spawn();
        }

        remainingEnemies = quantityToSpawn;
    }


    private void Spawn()
    {
        float randomX = UnityEngine.Random.Range(transform.position.x - spawnDistance, transform.position.x + spawnDistance);
        float randomY = UnityEngine.Random.Range(transform.position.y - spawnDistance, transform.position.y + spawnDistance);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

        if (!IsOverlapping(spawnPosition))
        {
            spawnedPositions.Add(spawnPosition);
            Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity);
        }
        else
        {
            Spawn();
        }
    }

    private bool IsOverlapping(Vector2 newSpawnPosition)
    {
        foreach (Vector2 position in spawnedPositions)
        {
            float distance = Vector2.Distance(position, newSpawnPosition);
            if (distance < 0.2f)
            {
                return true;
            }
        }
        return false;
    }

    public static int GetRemainingEnemies()
    {
        return remainingEnemies;
    }

    public static void SetRemainingEnemies(int numberOfEnemies)
    {
        remainingEnemies = numberOfEnemies;
    }

}
