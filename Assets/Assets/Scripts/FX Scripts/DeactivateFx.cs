using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFx : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("deactivate" , 3f);
    }

    void deactivate(){
        gameObject.SetActive(false);
    }

}
