using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashingLight : MonoBehaviour
{
    public Light2D light2D;

    [Header("Wait untill turning back on")]
    public float waitToTurnOnLowest;
    public float waitToTurnOnHighest;

    [Header("Wait untill turning back off")]
    public float waitToTurnOffLowest;
    public float waitToTurnOffHighest;

    void Start()
    {
        StartCoroutine(flashingLight());
    }

    IEnumerator flashingLight()
    {
        //Turns the light off
        light2D.intensity = 0;

        //Waits a random amount of time untill turning it back on
        float waitTime = Random.Range(waitToTurnOnLowest, waitToTurnOnHighest);
        yield return new WaitForSeconds(waitTime);

        //turns the light on to a random brightness
        float intensity = Random.Range(.1f, 1);
        light2D.intensity = intensity;

        //Waits a random amount of time untill turning it back off
        float waitTime2 = Random.Range(waitToTurnOffLowest, waitToTurnOffHighest);
        yield return new WaitForSeconds(waitTime2);

        //Repetes
        StartCoroutine(flashingLight());
    }
}
