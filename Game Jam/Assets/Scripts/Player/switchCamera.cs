using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SwitchCameraToNormal")
        {
            Camera.main.GetComponent<cameraFollow>().isInFall = false;
        }

        if (collision.gameObject.tag == "SwitchCameraToFall")
        {
            Camera.main.GetComponent<cameraFollow>().isInFall = true;
        }
    }
}
