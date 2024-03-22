using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScripts : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == TagManager.Player_Tag || other.tag == TagManager.Player_Health_Tag){
            GamePlayController.instance.coinCount++;
            gameObject.SetActive(false);
        }
    }
}
