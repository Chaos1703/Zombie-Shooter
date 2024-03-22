using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    public int damage;
    private float speed = 60f;
    private WaitForSeconds waitTime = new WaitForSeconds(2f);
    private IEnumerator coroutineDeactivate;
    private Vector3 direction;
    public GameObject rocketExplosion;
    void Start()
    {
        if(this.tag == TagManager.Rocket_Missile_Tag){
            speed = 8f;
        }
    }

    void OnEnable(){
        coroutineDeactivate = waitForDeactivate();
        StartCoroutine(coroutineDeactivate);
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnDisable()
    {
        if(coroutineDeactivate != null){
            StopCoroutine(coroutineDeactivate);
        }
    }

    public void setDirection(Vector3 dir){
        direction = dir;
    }
    IEnumerator waitForDeactivate(){
        yield return waitTime;
        gameObject.SetActive(false);
    }
    public void ExplodeFx(){
        AudioManager.instance.FenceExplosionSound();
        Instantiate(rocketExplosion , transform.position , Quaternion.identity);
    }
}
