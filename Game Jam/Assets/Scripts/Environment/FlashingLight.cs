using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashingLight : MonoBehaviour
{
    public Light2D light2D;

    public bool changesIntensity;

    [Header("Wait untill turning back on")]
    public float waitToTurnOnLowest;
    public float waitToTurnOnHighest;

    [Header("Wait untill turning back off")]
    public float waitToTurnOffLowest;
    public float waitToTurnOffHighest;

    private float defultLightIntensity;

    void Start()
    {
        defultLightIntensity = light2D.intensity;
        StartCoroutine(flashingLight());
    }

    IEnumerator flashingLight()
    {

        //Turns the light off
        light2D.intensity = 0;

        //Waits a random amount of time untill turning it back on
        float waitTime = Random.Range(waitToTurnOnLowest, waitToTurnOnHighest);
        yield return new WaitForSeconds(waitTime);

        if(changesIntensity == true)
        {
            //Turns the light on to a random brightness
            float intensity = Random.Range(.1f, 1);
            light2D.intensity = intensity;
        }
        else
        {
            //Turns the light to the intensity that it started at
            light2D.intensity = defultLightIntensity;
        }

        //Waits a random amount of time untill turning it back off
        float waitTime2 = Random.Range(waitToTurnOffLowest, waitToTurnOffHighest);
        yield return new WaitForSeconds(waitTime2);

        waitTime = 0;
        waitTime2 = 0;

        //Repetes
        StartCoroutine(flashingLight());
    }
}
