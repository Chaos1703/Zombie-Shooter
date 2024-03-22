using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private float moveForceX = 1.5f , moveForceY = 1.5f;
    private PlayerAnimations playerAnim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimations>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(h > 0){
            myBody.velocity = new Vector2 (moveForceX, myBody.velocity.y);
        }
        else if(h < 0){
            myBody.velocity = new Vector2 (-moveForceX, myBody.velocity.y);
        }
        else{
            myBody.velocity = new Vector2 (0f, myBody.velocity.y);
        }
        if(v > 0){
            myBody.velocity = new Vector2 (myBody.velocity.x, moveForceY);
        }
        else if(v < 0){
            myBody.velocity = new Vector2 (myBody.velocity.x, -moveForceY);
        }
        else{
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }
        if(myBody.velocity.sqrMagnitude != 0){
            playerAnim.PlayerRunAnimation(true);
        }
        else{
            playerAnim.PlayerRunAnimation(false);
        }
        Vector3 tempScale = transform.localScale;
        if(h > 0){
            tempScale.x = -1f;
        }
        else if(h < 0){
            tempScale.x = 1f;
        }
        transform.localScale = tempScale;
    }
}
