using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] gunSoundsClip;
    public AudioClip meeleSoundClip;
    public AudioSource playerAttackSource;
    public AudioSource zombieAttackSource;
    public AudioSource zombieDeadSource;
    public AudioSource zombieRiseSource;
    public AudioClip zombieRiseClip , zombieDeadClip;
    public AudioClip[] zombieAttackClip;
    public AudioSource fenceExplosionSource;
    public AudioClip fenceExplosionClip;

    void Awake()
    {
        MakeSingleton();
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void GunSound(int index){
        playerAttackSource.PlayOneShot(gunSoundsClip[index] , 1.0f);
    }
    public void playMelee(){
        playerAttackSource.PlayOneShot(meeleSoundClip , 1.0f);
    }
    public void ZombieRiseSound(){
        zombieRiseSource.PlayOneShot(zombieRiseClip, 1.0f);
    }
    public void ZombieDeadSound(){
        zombieDeadSource.PlayOneShot(zombieDeadClip, 1.0f);
    }
    public void ZombieAttackSound(){
        int index = Random.Range(0 , zombieAttackClip.Length);
        zombieAttackSource.PlayOneShot(zombieAttackClip[index] , 1.0f);
    }
    public void FenceExplosionSound(){
        fenceExplosionSource.PlayOneShot(fenceExplosionClip , 1.0f);
    }   

}
