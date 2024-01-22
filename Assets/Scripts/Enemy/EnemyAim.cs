using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private Transform transformWeapon;

    private bool isFacingRight = true;
    private GameObject player;
    public EnemyMovement enemyMovement;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transformWeapon = GetComponentInChildren<Sword>().transform;
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (enemyMovement.dead)
            {
                return;
            }
            UpdateWeaponPosition();
        }
    }

    private void UpdateWeaponPosition()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 rotation = (playerPosition - transform.position).normalized;

        float rotataionZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transformWeapon.eulerAngles = new Vector3(0, 0, rotataionZ);

        Vector3 weaponScale = transformWeapon.localScale;
        if (isFacingRight != (rotataionZ >= -90 && rotataionZ <= 90))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0, 180, 0));
            weaponScale.y *= -1;

        }
        transformWeapon.localScale = weaponScale;
    }
}
