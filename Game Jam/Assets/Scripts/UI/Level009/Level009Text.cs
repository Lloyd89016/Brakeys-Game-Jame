using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Level009Text : MonoBehaviour
{
    public Light2D light2D;
    public AudioSource Birds;

    public Text motherText;

    public GameObject effect;

    public GameObject image001;
    public GameObject image002;

    public void Start()
    {
        StartCoroutine(OpenEyes());
    }

    IEnumerator OpenEyes()
    {
        while(light2D.intensity < 15)
        {
            yield return new WaitForSeconds(.001f);
            light2D.intensity = light2D.intensity + .05f;
        }

        yield return new WaitForSeconds(.1f);

        Application.Quit();
    }
}
