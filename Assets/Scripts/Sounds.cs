using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sounds : MonoBehaviour
{
    public AudioSource enemySound1;
    public AudioSource enemySound2;
    public AudioSource enemySound3;
    public AudioSource bossSound1;
    public AudioSource bossSound2;
    public AudioSource bossSound3;
    private int randomForEnemies;
    
    private void Update()
    {
        randomForEnemies = Random.Range(0, 3);
    }

    public void EnemyHitSound()
    {
        if (randomForEnemies == 0)
        {
            enemySound1.Play();
        } else if (randomForEnemies == 1)
        {
            enemySound2.Play();
        } else if (randomForEnemies == 2)
        {
            enemySound3.Play();
        }
    }
    
    public void BossHitSound()
    {
        if (randomForEnemies == 0)
        {
            bossSound1.Play();
        } else if (randomForEnemies == 1)
        {
            bossSound2.Play();
        } else if (randomForEnemies == 2)
        {
            bossSound3.Play();
        }
    }
}
