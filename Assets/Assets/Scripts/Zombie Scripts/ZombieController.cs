using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private ZombieMovement zombieMovement;
    private ZombieAnimation zombieAnimation;
    private Transform targetTransform;
    private bool canAttack;
    private bool isAlive;
    public GameObject damageCollider;
    public int zombieHealth = 10;
    public int fireDamage = 10;
    public GameObject[] fxDead;
    public GameObject coin;
    private float timerAttack;

    void Start()
    {
        zombieMovement = GetComponent<ZombieMovement>();
        zombieAnimation = GetComponent<ZombieAnimation>();
        isAlive = true;
        if(GamePlayController.instance.zombieGoal == ZombieGoal.Player){
            targetTransform = GameObject.FindGameObjectWithTag(TagManager.Player_Tag).transform;
        }
        else if(GamePlayController.instance.zombieGoal == ZombieGoal.Fence){
            GameObject[] fences = GameObject.FindGameObjectsWithTag(TagManager.Fence_Tag);
            targetTransform = fences[Random.Range(0 , fences.Length)].transform;
        }
    }

    void Update()
    {
        if(isAlive){
            CheckDistance();
        }
    }

    void CheckDistance(){
        if(targetTransform != null){
            if(Vector3.Distance(transform.position, targetTransform.position) > 1.5f){
                zombieMovement.Move(targetTransform); 
            }  
            else if(GamePlayController.instance.PlayerAlive){
                zombieAnimation.Attack();
                timerAttack += Time.deltaTime;
                if(timerAttack > 0.65f){
                    timerAttack = 0f;
                    AudioManager.instance.ZombieAttackSound();
                }

            }
        }
    }

    void ActivateDamagePoint(){
        damageCollider.SetActive(true);
    }
    void DeactivateDamagePoint(){
        damageCollider.SetActive(false);
    }   

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == TagManager.Player_Health_Tag || target.tag == TagManager.Player_Tag || target.tag == TagManager.Fence_Tag){
            canAttack = true;
        }

        if(target.tag == TagManager.Bullet_Tag || target.tag == TagManager.Rocket_Missile_Tag){
            zombieAnimation.Hurt();
            zombieHealth -= target.gameObject.GetComponent<BulletController>().damage;
            if(target.tag == TagManager.Rocket_Missile_Tag){
                target.gameObject.GetComponent<BulletController>().ExplodeFx();
            }
            if(zombieHealth <= 0){
                isAlive = false;
                zombieAnimation.Dead();
                StartCoroutine(DeactivateZombie());
            }
            target.gameObject.SetActive(false);
        }
        if(target.tag == TagManager.Fire_Bullet_Tag){
            zombieAnimation.Hurt();
            zombieHealth -= fireDamage;
            if(zombieHealth <= 0){
                isAlive = false;
                zombieAnimation.Dead();
                StartCoroutine(DeactivateZombie());
            }
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if(target.tag == TagManager.Player_Health_Tag || target.tag == TagManager.Player_Tag || target.tag == TagManager.Fence_Tag){
            canAttack = false;
        }
        
    }

    public void ActivateDeadEffect(int index){
        fxDead[index].SetActive(true);
        if(fxDead[index].GetComponent<ParticleSystem>() != null){
            fxDead[index].GetComponent<ParticleSystem>().Play();
        }
    }
    IEnumerator DeactivateZombie(){
        AudioManager.instance.ZombieDeadSound();
        yield return new WaitForSeconds(2f);
        if(GamePlayController.instance.gameGoal == GameGoal.killZombie)
            GamePlayController.instance.ZombieDied();  
        if(Random.Range(0 , 10) > 6)
            Instantiate(coin , transform.position , Quaternion.identity); 
        gameObject.SetActive(false);
    }

    public void DealDamage(int damage){
        zombieAnimation.Hurt();
        zombieHealth -= damage;
        if(zombieHealth <= 0){
            isAlive = false;
            zombieAnimation.Dead();
            StartCoroutine(DeactivateZombie());
        }
    }
}