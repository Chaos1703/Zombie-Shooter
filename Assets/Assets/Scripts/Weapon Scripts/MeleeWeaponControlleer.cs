using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponControlleer : WeaponController
{
    public override void processAttack(){
        if(weaponName == weaponName.Melee){
            AudioManager.instance.playMelee();
        }
    }
}
