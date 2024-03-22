using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefabs;
    public Transform spawnPoint;
    public GameObject FxShred;
    private GameObject Zombie;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.Player_Tag).transform;
        FxShred.SetActive(true);
        AudioManager.instance.ZombieRiseSound();
        Zombie = Instantiate(zombiePrefabs , spawnPoint.position , Quaternion.identity);
        if(Zombie.transform.position.x < player.position.x){
            Zombie.transform.localScale = new Vector3(-1f , 1f , 1f);
        }
        else if(Zombie.transform.position.x > player.position.x){
            Zombie.transform.localScale = new Vector3(1f , 1f , 1f);
        }

        StartCoroutine(WaitAndDeactivate());
    }

    IEnumerator WaitAndDeactivate(){
        yield return new WaitForSeconds(Random.Range(1f , 3f));
        FxShred.SetActive(false);
    }
}

