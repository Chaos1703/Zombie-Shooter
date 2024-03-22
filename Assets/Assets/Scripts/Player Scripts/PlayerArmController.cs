using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{
    public Sprite OneHandSprite , TwoHandSprite;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    public void ChangeToOneHand(){
        sr.sprite = OneHandSprite;
    }

    public void ChangeToTwoHand(){
        sr.sprite = TwoHandSprite;
    }
}
