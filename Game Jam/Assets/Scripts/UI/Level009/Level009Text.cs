using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Level009Text : MonoBehaviour
{
    public Text motherText;
    public Text fatherText;

    public Light2D light2D;

    public Text buttonPromptText;

    private bool canOpenEyes;

    public void Start()
    {
        buttonPromptText.text = "E to open eyes";

        canOpenEyes = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canOpenEyes == true)
        {
            StartCoroutine(OpenEyes());
        }
    }

    IEnumerator OpenEyes()
    {
        while(light2D.intensity < 15)
        {
            yield return new WaitForSeconds(.1f);
            light2D.intensity = light2D.intensity + .1f;
        }

        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Credits");
    }
}
