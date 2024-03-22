using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public int health = 100;
   public GameObject[] bloodFx;
   private PlayerAnimations playerAnim;

   void Awake()
   {
        playerAnim = GetComponentInParent<PlayerAnimations>();
   }

    public void DealDamage(int damage){
        health -= damage;   
        GamePlayController.instance.playerLifeCounter(health);
        playerAnim.PlayerGetHurtAnimation();
        if(health <= 0){
            GamePlayController.instance.PlayerAlive = false;
            GetComponent<Collider2D>().enabled = false;
            playerAnim.PlayerDeadAnimation();
            bloodFx[Random.Range(0,bloodFx.Length)].SetActive(true);
            GamePlayController.instance.GameOver();
        }
    }
}
