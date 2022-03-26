using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level007TextManager : MonoBehaviour
{
    public Text motherText;
    public Text monsterText;
    public Text fatherText;

    public GameObject wakeUpButton;
    public GameObject stayButton;

    void Start()
    {
        StartCoroutine(enemyTalk());
    }

    IEnumerator enemyTalk()
    {
        //Mother Text line
        motherText.text = "Wake up";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "What is that voice?";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(1);

        //Mother Text line
        motherText.text = "Come on son. Please wake up";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "Ignore it! Don't listen.";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "You don't have to listen to it.";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "It doesn't control you";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(1);

        //Mother Text line
        motherText.text = "Please wake up";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "No.";
        yield return new WaitForSeconds(3);
        //Monster Text Line
        monsterText.text = "Don't do it.";
        yield return new WaitForSeconds(1);
        //Monster Text Line
        monsterText.text = "Don't abondoned me!";
        yield return new WaitForSeconds(3);
        //Monster Text Line
        monsterText.text = "Please...";
        yield return new WaitForSeconds(1);
        monsterText.text = "";

        wakeUpButton.SetActive(true);
        stayButton.SetActive(true);
    }



    public void stay()
    {
        StartCoroutine(stayText());
    }

    IEnumerator stayText()
    {
        wakeUpButton.SetActive(false);
        stayButton.SetActive(false);

        //Mother Text line
        motherText.text = "H- he's stops breathing";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        //Mother Text line
        motherText.text = "John. Oh god John, he's stopped breathing";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        motherText.text = "Do something, you're a doctor aren't you?";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        fatherText.text = "What should I do?";
        yield return new WaitForSeconds(3);
        fatherText.text = "";
        yield return new WaitForSeconds(3);


        motherText.text = "Anything, Just keep my baby alive";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        fatherText.text = "Let me look at him";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        fatherText.text = "...H-He's gone";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Let's go back home. My darling child.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Now we can finally be togther.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Forever.";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Credits");
    }



    public void Leave()
    {
        StartCoroutine(LeaveText());
    }

    IEnumerator LeaveText()
    {
        wakeUpButton.SetActive(false);
        stayButton.SetActive(false);

        //Monster Text Line
        monsterText.text = "Why would you leave me? I thought we were firends.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Fine.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Just-";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Just go.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "I will just stay here.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Alone.";
        yield return new WaitForSeconds(3);


        //Monster Text Line
        monsterText.text = "For eternity";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Fairwell child.";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}