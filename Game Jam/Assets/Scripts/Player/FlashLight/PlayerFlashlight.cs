using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerFlashlight : MonoBehaviour
{
    public float chargeLeft;
    public LayerMask rechargeLayerMask;
    GameObject flashlightLight;
    GameObject groundChecker;
    GameObject player;

    public float chargeDetectionRadius = 5f;

    private Vector3 diff;
    private float rotZ;

    private void Start()
    {
        flashlightLight = GameObject.Find("FlashLight");
        groundChecker = GameObject.Find("GroundChecker");
        player = GameObject.Find("Player");
        StartCoroutine(decreaseCharge());
    }

    void Update()
    {
        transform.position = player.transform.position;

        //I may have stole this code off of reddit... 
        
        //bruh L, if you steal you won't learn anything... but anyways...
        
        //ok mr tutorial man

        //(It makes the player point towards the mouse)

        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //normalize difference  
        diff.Normalize();

        //calculate rotation
        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //apply to object
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);


        //turns off the flashlight if theres no charge

        if (chargeLeft <= 0)
        {
            flashlightLight.SetActive(false);
        }
        else
        {
            flashlightLight.SetActive(true);
        }

        if(Physics2D.OverlapCircle(groundChecker.transform.position, chargeDetectionRadius, rechargeLayerMask))
        {
            flashlightLight.GetComponent<Light2D>().intensity = 1;
            chargeLeft = 5;
        }
    }

    IEnumerator decreaseCharge()
    {
        if (chargeLeft > 0)
        {
            yield return new WaitForSeconds(1f);

            chargeLeft -= 1;
            flashlightLight.GetComponent<Light2D>().intensity -= .2f;
            StartCoroutine(decreaseCharge());
        }
        else
        {
            yield return new WaitForSeconds(.2f);
            StartCoroutine(decreaseCharge());
        }
    }

}
