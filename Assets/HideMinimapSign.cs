using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMinimapSign : MonoBehaviour
{
    private GameObject circleObject;
    private EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        Transform circleTransform = transform.Find("Circle");
        circleObject  = circleTransform.gameObject;
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMovement.Dead){
            circleObject.SetActive(false);
        }
    }
}
