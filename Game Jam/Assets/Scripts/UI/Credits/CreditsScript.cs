using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsScript : MonoBehaviour
{
    public TextMeshProUGUI creditsText;

    public void Start()
    {
        StartCoroutine(changeCredits());
    }

    IEnumerator changeCredits()
    {
        yield return new WaitForSeconds(.5f);


        creditsText.text = "Eveything by lloyd";
        yield return new WaitForSeconds(5f);


        SceneManager.LoadScene("MainMenu");
    }
}
