using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassableFloor : MonoBehaviour
{
    public BoxCollider2D SolidCollider;
    public passableFloor_playerChecker playerChecker;


    void Start()
    {
        playerChecker = transform.GetChild(0).GetComponent<passableFloor_playerChecker>();
    }

    void Update()
    {
        if (playerChecker.makeSolid == true)
        {
            SolidCollider.isTrigger = false;
        }
        else if (playerChecker.makeSolid == false)
        {
            SolidCollider.isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }

}
