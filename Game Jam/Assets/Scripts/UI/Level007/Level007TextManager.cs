using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level007TextManager : MonoBehaviour
{
    public Text motherText;
    public Text MonsterText;
    public Text FatherText;

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
        MonsterText.text = "What is that voice?";
        yield return new WaitForSeconds(3);
        MonsterText.text = "";
        yield return new WaitForSeconds(1);

        //Mother Text line
        motherText.text = "Come on son. Please wake up";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        MonsterText.text = "Ignore it! Don't listen.";
        yield return new WaitForSeconds(3);
        MonsterText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        MonsterText.text = "You don't have to listen to it.";
        yield return new WaitForSeconds(3);
        MonsterText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        MonsterText.text = "It doesn't control you";
        yield return new WaitForSeconds(3);
        MonsterText.text = "";
        yield return new WaitForSeconds(1);

        //Mother Text line
        motherText.text = "Please wake up";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        MonsterText.text = "No.";
        yield return new WaitForSeconds(3);
        //Monster Text Line
        MonsterText.text = "Don't do it.";
        yield return new WaitForSeconds(1);
        //Monster Text Line
        MonsterText.text = "Don't abondoned me!";
        yield return new WaitForSeconds(3);
        //Monster Text Line
        MonsterText.text = "Please...";
        yield return new WaitForSeconds(1);
        MonsterText.text = "";

        wakeUpButton.SetActive(true);
        stayButton.SetActive(true);
    }



    public void stay()
    {
        StartCoroutine(stayText());
    }

    IEnumerator stayText()
    {
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

        FatherText.text = "What should I do??";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);


        motherText.text = "Anything, Just keep my baby alive";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        FatherText.text = "Let me look at him";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        FatherText.text = "...H-He's gone";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Let's go back home. My darling child.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Now we can finally be togther.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Evermore.";
        yield return new WaitForSeconds(3);
        MonsterText.text = "";
        yield return new WaitForSeconds(3);


    }



    public void Leave()
    {
        StartCoroutine(LeaveText());
    }

    IEnumerator LeaveText()
    {
        //Monster Text Line
        MonsterText.text = "Why would you leave me? I thought we were firends.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Fine.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Just-";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Just go.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "I will just stay here.";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Alone.";
        yield return new WaitForSeconds(3);


        //Monster Text Line
        MonsterText.text = "For eternity";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        MonsterText.text = "Fairwell child.";
        yield return new WaitForSeconds(3);
    }
}