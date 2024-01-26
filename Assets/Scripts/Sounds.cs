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

    public void EnemyHitSound()
    {
        int randomSound = Random.Range(0, 3);
        switch (randomSound)
        {
            case 0:
                enemySound1.Play();
                break;
            case 1:
                enemySound2.Play();
                break;
            case 2:
                enemySound3.Play();
                break;
        }
    }

    public void BossHitSound()
    {
        int randomSound = Random.Range(0, 3);
        switch (randomSound)
        {
            case 0:
                bossSound1.Play();
                break;
            case 1:
                bossSound2.Play();
                break;
            case 2:
                bossSound3.Play();
                break;
        }
    }
}
