using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateSMB : StateMachineBehaviour
{
   public int numberAnimations;
   public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      animator.SetInteger("Random", Random.Range(0, numberAnimations));
      int random = Random.Range(1 , numberAnimations + 1);
      animator.SetInteger(TagManager.Random_Parameter, random);
   }

}
