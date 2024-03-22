using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public int damage = 3;
    void Update()
    {
        if(GamePlayController.instance.zombieGoal == ZombieGoal.Player)
            AttackPlayer();
        if(GamePlayController.instance.zombieGoal == ZombieGoal.Fence)
            AttackFence();
    }

    void AttackPlayer(){
        if(GamePlayController.instance.PlayerAlive){
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);
            if(target != null && target.tag == TagManager.Player_Health_Tag){
                target.GetComponent<PlayerHealth>().DealDamage(damage);
            }
        }
    }

    void AttackFence(){
        if(!GamePlayController.instance.fenceDestroyed){
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);
            if(target != null && target.tag == TagManager.Fence_Tag){
                target.GetComponent<FenceHealth>().DealDamage(damage);
            }
        }
    }
}

