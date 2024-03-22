using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponContoller : WeaponController
{
   public Transform spawnPoint;
   public GameObject bullet;
   public ParticleSystem muzzleFlash;
   public GameObject fx_BulletFall;
   private Collider2D FireCollider;
   private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
   private WaitForSeconds FireColliderWait = new WaitForSeconds(0.02f);

    void Start()
    {
        if(!GamePlayController.instance.createBulletAndBulletFx){
            if(weaponName != weaponName.Firegun && weaponName != weaponName.RocketLauncher){
                GamePlayController.instance.createBulletAndBulletFx = true;
                SmartPool.instance.createBulletAndBulletFall(bullet , fx_BulletFall , 100);
            }
        }
        if(!GamePlayController.instance.createRocketBullet){
            if(weaponName == weaponName.RocketLauncher){
                GamePlayController.instance.createRocketBullet = true;
                SmartPool.instance.createRocketBullet(bullet , 100);
            }
        }
        if(weaponName == weaponName.Firegun){
            FireCollider = spawnPoint.GetComponent<Collider2D>();
            FireCollider.enabled = false;
        }
    }

    public override void processAttack(){
        switch(weaponName){
            case weaponName.Pistol:
                AudioManager.instance.GunSound(0);
                break;
            case weaponName.Mp5:
                AudioManager.instance.GunSound(1);
                break;
            case weaponName.Ak47:
                AudioManager.instance.GunSound(2);
                break;
            case weaponName.Shotgun:
                AudioManager.instance.GunSound(3);
                break;
            case weaponName.Sniper:
                AudioManager.instance.GunSound(4);
                break;
            case weaponName.RocketLauncher:
                AudioManager.instance.GunSound(5);
                break;
            case weaponName.Firegun:
                AudioManager.instance.GunSound(6);
                break;
        }
        if(transform!=null && weaponName != weaponName.Firegun  && weaponName != weaponName.Melee){
            if(weaponName != weaponName.RocketLauncher){
                GameObject bulletFallFx = SmartPool.instance.spawnBulletFallFx(spawnPoint.transform.position , Quaternion.identity);
                bulletFallFx.transform.localScale = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1f , 1f , 1f) : Vector3.one;
                StartCoroutine("WaitForShoot");
            }
            SmartPool.instance.spawnBullet(spawnPoint.transform.position , new Vector3(-transform.root.localScale.x , 0f , 0f) , spawnPoint.rotation , weaponName);
        }

        if(weaponName == weaponName.Firegun){
            StartCoroutine("ActivateFireCollider");
        }
    }
    IEnumerator WaitForShoot(){
        yield return waitTime;
        muzzleFlash.Play();
    }

    IEnumerator ActivateFireCollider(){
        FireCollider.enabled = true;
        muzzleFlash.Play();
        yield return FireColliderWait;
        FireCollider.enabled = false;
    }
    
}
    