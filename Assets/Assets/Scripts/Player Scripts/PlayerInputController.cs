using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private WeaponManager weaponManager;
    [HideInInspector]
    public bool canShoot;
    private bool isHoldAttack;

    void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            weaponManager.switchWeapon();
        }   

        if(Input.GetKey(KeyCode.Mouse0))
            isHoldAttack = true;
        else{
            weaponManager.resetAttack();
            isHoldAttack = false;
        }

        if(isHoldAttack && canShoot){
            weaponManager.Attack();
        }
    }
}
