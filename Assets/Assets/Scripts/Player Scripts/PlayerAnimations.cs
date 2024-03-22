using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   private Animator anim;

   void Awake()
   {
        anim = GetComponent<Animator>();
   }
   public void PlayerRunAnimation(bool run){
       anim.SetBool(TagManager.Run_Parameter, run);
    }
    public void PlayerAttackAnimation(){
        anim.SetTrigger(TagManager.Attack_Parameter);
    }
    public void PlayerSwitchWeaponAnimation(int typeWeapon){
        anim.SetInteger(TagManager.Type_Weapon_Parameter, typeWeapon);
        anim.SetTrigger(TagManager.Switch_Parameter);
    }

    public void PlayerGetHurtAnimation(){
        anim.SetTrigger(TagManager.GetHurt_Parameter);
    }

    public void PlayerDeadAnimation(){
        anim.SetTrigger(TagManager.Dead_Parameter);
    }
}
