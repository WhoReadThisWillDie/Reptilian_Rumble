using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerAim : MonoBehaviour
{
    private Camera mainCamera;
    private Transform transformWeapon;
    private bool isFacingRight = true;
    public PlayerM playerM;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transformWeapon = GetComponentInChildren<Sword>().transform;
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (playerM.dead)
            {
                return;
            }
            UpdateWeaponPosition();
        }
    }

    private void UpdateWeaponPosition()
    {

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = (mousePosition - transform.position).normalized;

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
