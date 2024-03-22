using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceHealth : MonoBehaviour
{
    public int health = 100;
    public ParticleSystem woodBreakFx , woodExplodeFx;

    public void DealDamage(int damage){
        health -= damage;
        woodBreakFx.Play();
        if(health <= 0){
            health = 0;
            woodExplodeFx.Play();
            AudioManager.instance.FenceExplosionSound();
            StartCoroutine(DeactivateFence());
            GamePlayController.instance.fenceDestroyed = true;
        }
    }

    IEnumerator DeactivateFence(){
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
