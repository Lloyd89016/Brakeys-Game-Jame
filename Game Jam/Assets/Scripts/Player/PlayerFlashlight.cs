using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private Vector3 diff;
    private float rotZ; 

    void Update()
    {

        //I may have stole this code off of reddit...
        //(It makes the player point towards the mouse)

        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //normalize difference  
        diff.Normalize();

        //calculate rotation
        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //apply to object
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
