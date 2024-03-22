using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeControlAttack{Click, Hold}
public enum TypeWeapon{melee , oneHand , twoHand}
[System.Serializable]
public struct DefaultConfig{
    public TypeControlAttack typeControlAttack;
    public TypeWeapon typeWeapon;
    [Range(0,100)]
    public int damage;
    [Range(0,100)]
    public int criticalDamage;
    [Range(0.1f,1f)]
    public float attackSpeed;
    [Range(0,100)]
    public int criticalRate;
}
