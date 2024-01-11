using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInactiveOnStart : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
}
