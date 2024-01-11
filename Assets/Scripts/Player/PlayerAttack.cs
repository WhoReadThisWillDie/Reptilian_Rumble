using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Sword sword;

    void Start()
    {
        sword = GetComponentInChildren<Sword>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sword.Attack();
        }
    }
}
