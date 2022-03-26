using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level009Text : MonoBehaviour
{
    public Text motherText;
    public Text fatherText;

    public Image backDrop;

    public Text buttonPromptText;

    private bool canOpenEyes;

    void Start()
    {
        StartCoroutine(ChangeText());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canOpenEyes == true)
        {
            StartCoroutine(OpenEyes());
        }
    }

    IEnumerator ChangeText()
    {
        //Mother Text line
        motherText.text = "His eye twitched! Oh please be ok.";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Mother Text line
        motherText.text = "You can do it son open your eyes.";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Father Text line
        fatherText.text = "You can do it kid.";
        yield return new WaitForSeconds(3);
        fatherText.text = "";
        yield return new WaitForSeconds(1);

        buttonPromptText.text = "E to open eyes";

        canOpenEyes = true;
    }

    IEnumerator OpenEyes()
    {
        backDrop.color = Color.white;
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("Credits");
    }
}
