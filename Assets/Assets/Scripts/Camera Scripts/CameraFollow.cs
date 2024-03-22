using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.Player_Tag).transform;
    }

    void Update()
    {
        if(GamePlayController.instance.gameGoal != GameGoal.defendFence && GamePlayController.instance.gameGoal != GameGoal.gameOver){
            if(player){
            Vector3 temp = transform.position;
            temp.x = player.transform.position.x;
            transform.position = temp;
            }
        }
    }
}
