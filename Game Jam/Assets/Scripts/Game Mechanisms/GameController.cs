using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; // the lights module by which we control the lights
using UnityEngine.UI;// ui system
using TMPro; // importing text mesh pro

public class GameController : MonoBehaviour
{
    // this is the game controller script which controls the game. :|

    [Header("Level 1 Settings")]
    public GameObject player;
    //public TMP_Text playerTMP;
    public Light2D globalLightL1;
    public float globalLightstartIntensity;

    // Start is called before the first frame update
    void Start()
    {
        globalLightL1.intensity = globalLightstartIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
