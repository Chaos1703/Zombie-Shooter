using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject meeleDamagePoint;
    public List<WeaponController> weapon_Unlocked;
    public WeaponController[] totalWeapon;
    private int currentWeaponIndex;
    [HideInInspector]
    public WeaponController currentWeapon;
    private TypeControlAttack currentTypeControl;
    private PlayerArmController[] ArmController;
    private PlayerAnimations playerAnim;
    private bool isShooting;

    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        loadActiveWeapons();  
        currentWeaponIndex = 1;
    }
    
    void Start()
    {
        ArmController = GetComponentsInChildren<PlayerArmController>();
        changeWeapon(weapon_Unlocked[1]);
        playerAnim.PlayerSwitchWeaponAnimation((int)weapon_Unlocked[currentWeaponIndex].defaultConfig.typeWeapon);
    }

    void loadActiveWeapons(){
        weapon_Unlocked.Add(totalWeapon[0]);
        for(int i = 1; i < totalWeapon.Length; i++){
            weapon_Unlocked.Add(totalWeapon[i]);
        }
    }

    public void switchWeapon(){
        currentWeaponIndex++;
        if(currentWeaponIndex >= weapon_Unlocked.Count){
            currentWeaponIndex = 0;
        }
        playerAnim.PlayerSwitchWeaponAnimation((int)weapon_Unlocked[currentWeaponIndex].defaultConfig.typeWeapon);
        changeWeapon(weapon_Unlocked[currentWeaponIndex]);
    }

    void changeWeapon(WeaponController weapon){
        if(currentWeapon != null){
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = weapon;
        weapon.gameObject.SetActive(true);
        currentTypeControl = weapon.defaultConfig.typeControlAttack;
        if(weapon.defaultConfig.typeWeapon == TypeWeapon.oneHand){
            for(int i = 0; i<ArmController.Length; i++){
                ArmController[i].ChangeToTwoHand();
            }
        }
        else{
            for(int i = 0; i<ArmController.Length; i++){
                ArmController[i].ChangeToOneHand();
            }
        }
    }

    public void Attack(){
        if(currentTypeControl == TypeControlAttack.Hold){
            currentWeapon.callAttack();
        }
        else if(currentTypeControl == TypeControlAttack.Click){
            if(!isShooting){
                currentWeapon.callAttack();
                isShooting = true;
            }
        }
    }

    public void resetAttack(){
        if(currentTypeControl == TypeControlAttack.Click){
            isShooting = false;
        }
    }

    void AllowCollisionDetection(){
        meeleDamagePoint.SetActive(true);
    }
    void DenyCollisionDetection(){
        meeleDamagePoint.SetActive(false);
    }
}
