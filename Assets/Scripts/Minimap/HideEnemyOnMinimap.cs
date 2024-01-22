using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMinimapSign : MonoBehaviour
{
    private GameObject circleObject;
    private EnemyMovement enemyMovement;

    void Start()
    {
        Transform circleTransform = transform.Find("Circle");
        circleObject = circleTransform.gameObject;
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if (enemyMovement.dead)
        {
            circleObject.SetActive(false);
        }
    }
}
