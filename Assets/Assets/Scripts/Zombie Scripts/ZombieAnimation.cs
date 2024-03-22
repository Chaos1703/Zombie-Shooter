using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetTrigger(TagManager.Attack_Parameter);
    }

    public void Hurt()
    {
        anim.SetTrigger(TagManager.GetHurt_Parameter);
    }

    public void Dead()
    {
        anim.SetTrigger(TagManager.Dead_Parameter);
    }

}
