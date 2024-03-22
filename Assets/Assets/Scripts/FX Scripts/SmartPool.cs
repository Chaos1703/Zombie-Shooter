using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;
    private List<GameObject> bulletFallFx = new List<GameObject>();
    private List<GameObject> bulletPrefabs = new List<GameObject>();
    private List<GameObject> rocketBulletPrefabs = new List<GameObject>();
    public GameObject[] zombies;
    private float  ySpawnMin = -3.7f , ySpwanMx = -0.36f;
    private Camera MainCamera;

    void Awake()
    {
        MainCamera = Camera.main;
        makeInstance();
    }

    void Start()
    {
        InvokeRepeating("SpawningZombies" , 1f , Random.Range(1f , 4f));
    }

    void OnDisable()
    {
        instance = null;
    }

    void makeInstance(){
        if(instance == null)
            instance = this;
    }

    public void createBulletAndBulletFall(GameObject bullet , GameObject bulletFall , int count){
        for(int i = 0 ; i < count ; i++){
            GameObject tempBullet = Instantiate(bullet);
            GameObject tempBulletFall = Instantiate(bulletFall);
            bulletPrefabs.Add(tempBullet);
            bulletFallFx.Add(tempBulletFall);
            bulletFallFx[i].SetActive(false);
            bulletPrefabs[i].SetActive(false);
        }
    }

    public void createRocketBullet(GameObject rocketBullet , int count){
        for(int i = 0 ; i < count ; i++){
            GameObject tempRocketBullet = Instantiate(rocketBullet);
            rocketBulletPrefabs.Add(tempRocketBullet);
            rocketBulletPrefabs[i].SetActive(false);
        }
    }

    public GameObject spawnBulletFallFx(Vector3 position , Quaternion rotation){
        for(int i = 0 ; i < bulletFallFx.Count ; i++){
            if(!bulletFallFx[i].activeInHierarchy){
                bulletFallFx[i].SetActive(true);
                bulletFallFx[i].transform.position = position;
                bulletFallFx[i].transform.rotation = rotation;  
                return bulletFallFx[i];
            }
        }
        return null;
    }

    public void spawnBullet(Vector3 position , Vector3 direction , Quaternion rotation , weaponName weapon){
        if(weapon != weaponName.RocketLauncher){
            for(int i = 0 ; i < bulletPrefabs.Count ; i++){
                if(!bulletPrefabs[i].activeInHierarchy){
                    bulletPrefabs[i].SetActive(true);
                    bulletPrefabs[i].transform.position = position;
                    bulletPrefabs[i].transform.rotation = rotation; 
                    bulletPrefabs[i].GetComponent<BulletController>().setDirection(direction);
                    SetBulletDamage(weapon , bulletPrefabs[i]);
                    break;
                }
            }
        }
        else{
            for(int i = 0 ; i < rocketBulletPrefabs.Count ; i++){
                if(!rocketBulletPrefabs[i].activeInHierarchy){
                    rocketBulletPrefabs[i].SetActive(true);
                    rocketBulletPrefabs[i].transform.position = position;
                    rocketBulletPrefabs[i].transform.rotation = rotation; 
                    rocketBulletPrefabs[i].GetComponent<BulletController>().setDirection(direction);
                    SetBulletDamage(weapon , rocketBulletPrefabs[i]);
                    break;
                }
            }
        }
    } 
    void SetBulletDamage(weaponName weapon , GameObject bullet){
        switch(weapon){
            case weaponName.Pistol:
                bullet.GetComponent<BulletController>().damage = 2;
                break;
            case weaponName.Mp5:
                bullet.GetComponent<BulletController>().damage = 3;
                break;
            case weaponName.Ak47:
                bullet.GetComponent<BulletController>().damage = 1;
                break;
            case weaponName.Shotgun:
                bullet.GetComponent<BulletController>().damage = 4;
                break;
            case weaponName.Sniper:
                bullet.GetComponent<BulletController>().damage = 10;
                break;
            case weaponName.RocketLauncher:
                bullet.GetComponent<BulletController>().damage = 12;
                break;
        }
    }

    void SpawningZombies(){
        if(GamePlayController.instance.gameGoal == GameGoal.defendFence){
            float xPos = MainCamera.transform.position.x;
            xPos += 15f;
            float yPos = Random.Range(ySpawnMin , ySpwanMx);
            Instantiate(zombies[Random.Range(0 , zombies.Length)] , new Vector3(xPos , yPos , 0f) , Quaternion.identity);
        }
        else if(GamePlayController.instance.gameGoal == GameGoal.gameOver){
            CancelInvoke("SpawningZombies");
        }
        else{
            float xPos = MainCamera.transform.position.x;
            if(Random.Range(0,2) > 0){
                xPos += Random.Range(10f , 15f);
            }
            else{
                xPos -= Random.Range(10f , 15f);
            }
            float yPos = Random.Range(ySpawnMin , ySpwanMx);
            Instantiate(zombies[Random.Range(0 , zombies.Length)] , new Vector3(xPos , yPos , 0f) , Quaternion.identity);
        }
    }
} 
