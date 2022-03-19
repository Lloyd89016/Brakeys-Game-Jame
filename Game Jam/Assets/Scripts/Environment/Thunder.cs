using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public AudioSource thunder;

    [Header("Wait untill playing sound again")]
    public float waitToTurnOnLowest;
    public float waitToTurnOnHighest;

    void Start()
    {
        StartCoroutine(flashingLight());
    }

    IEnumerator flashingLight()
    {
        //Waits a random amount of time untill playing sound again
        float waitTime = Random.Range(waitToTurnOnLowest, waitToTurnOnHighest);
        yield return new WaitForSeconds(waitTime);

        //Sets the sound to a random volume
        float soundVolume = Random.Range(.2f, 1f);
        thunder.volume = soundVolume;

        //Sets the sound to a random volume
        float soundPitch = Random.Range(.2f, 1f);
        thunder.pitch = soundPitch;

        //Playes the sound
        thunder.Play();

        //Waits untill sound finishes
        yield return new WaitForSeconds(3);

        //Repetes
        StartCoroutine(flashingLight());
    }
}
