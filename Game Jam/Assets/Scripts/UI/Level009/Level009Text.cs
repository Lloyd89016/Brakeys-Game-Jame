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

        light2D.intensity = 0;
        effect.SetActive(false);
        image001.SetActive(false);
        image002.SetActive(true);
        Birds.Play();

        motherText.text = "Good Morning son.";

        yield return new WaitForSeconds(2f);

        motherText.text = "That must have been quite a dream you were having!";

        yield return new WaitForSeconds(2f);
        
        motherText.text = "";

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("Credits");
    }
}
