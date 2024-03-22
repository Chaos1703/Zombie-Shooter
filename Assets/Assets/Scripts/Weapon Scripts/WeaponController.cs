using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weaponName{Melee , Pistol , Mp5 , Ak47 , Shotgun , Sniper , RocketLauncher , Firegun}
public class WeaponController : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public weaponName weaponName;
    protected  PlayerAnimations playerAnim;
    protected float lastShot;
    public int gunIndex;
    public int currentBullet;
    public int maxBullet;
    
    void Awake()
    {
        playerAnim = FindObjectOfType<PlayerAnimations>();
        currentBullet = maxBullet;

    }

    public void callAttack(){
        if(Time.time > lastShot + defaultConfig.attackSpeed && currentBullet > 0){
            playerAnim.PlayerAttackAnimation();
            processAttack();
            lastShot = Time.time;
            currentBullet--;
        }
        else if(currentBullet <= 0){
            
        }
    }

    public virtual void processAttack(){}
}
