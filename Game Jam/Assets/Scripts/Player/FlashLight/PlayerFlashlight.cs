using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerFlashlight : MonoBehaviour
{
    public bool cheatModeOn = true; // dont forget to turn this off
    public float chargeLeft;
    public LayerMask rechargeLayerMask;
    GameObject flashlightLight;
    GameObject groundChecker;
    GameObject player;
    [SerializeField] private LayerMask wallLayerMask;
    bool flashLightTouchingWall;
    public float rayCastDistance;
    RaycastHit2D flashlightTouchingWall;

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
        if (cheatModeOn)
        {
            chargeLeft = 10;
        }
        //Debug.Log("test125");
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











    //private void FixedUpdate() This is just the code i did to try to fix the flashlight, tried to draw a raycast but i failed to realise the raycast wont rotate like the torch.
    //{
    //    //flashlightTouchingWall = Physics2D.Raycast(transform.position, rayCastDistance, wallLayerMask);

    //    //if (flashlightTouchingWall.collider != null)
    //    //{
    //    //    Debug.Log("Wall is in the way bruh");
    //    //} buggggg 
    //} code that i wrote for trying to fix the flashlight -- commented 

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Debug.Log($"flashlighttouchingwall variable : {flashlightTouchingWall}"); // checking the flashlight touching variable
    //    Debug.Log("bruh colliding with something");
    //    Debug.DrawRay(transform.position, Input.mousePosition, Color.blue); // why does this not work :(

    //    Debug.Log($"Flashlight in the way?: {flashlightTouchingWall.collider != null}");

    //} code that i wrote for trying to fix the flashlight -- commented

}
