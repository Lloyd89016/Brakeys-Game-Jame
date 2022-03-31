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
        yield return new WaitForSeconds(1);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Mother Text line
        motherText.text = "Son. Wake up, you're having a nightmare.";
        yield return new WaitForSeconds(3);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "Ignore her.";
        yield return new WaitForSeconds(1.5f);
        monsterText.text = "";
        yield return new WaitForSeconds(.5f);

        //Mother Text line
        motherText.text = "Come on son, Please wake up.";
        yield return new WaitForSeconds(2);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "She doesn't know what's best for you.";
        yield return new WaitForSeconds(2f);
        monsterText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "You don't have to listen.";
        yield return new WaitForSeconds(1.5f);
        monsterText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "I can take care of you.";
        yield return new WaitForSeconds(1.5f);
        monsterText.text = "";
        yield return new WaitForSeconds(.5f);

        //Mother Text line
        motherText.text = "Wake up";
        yield return new WaitForSeconds(1);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "No.";
        yield return new WaitForSeconds(1);
        //Monster Text Line
        monsterText.text = "Don't do it.";
        yield return new WaitForSeconds(1);
        //Monster Text Line
        monsterText.text = "Don't abandon me.";
        yield return new WaitForSeconds(2f);
        //Monster Text Line
        monsterText.text = "Please.";
        yield return new WaitForSeconds(1.5f);

        //Monster Text Line
        monsterText.text = "";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "Please...";
        yield return new WaitForSeconds(1.5f);
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
        motherText.text = "H- He's stopped breathing.";
        yield return new WaitForSeconds(2f);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Mother Text line
        motherText.text = "John. Oh god John, he's stopped breathing.";
        yield return new WaitForSeconds(2.3f);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        motherText.text = "John, Do something!";
        yield return new WaitForSeconds(1.5f);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        fatherText.text = "What should I do!?";
        yield return new WaitForSeconds(1.5f);
        fatherText.text = "";
        yield return new WaitForSeconds(.5f);


        motherText.text = "Anything, Just keep my baby alive.";
        yield return new WaitForSeconds(2);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        fatherText.text = "Let me look at him.";
        yield return new WaitForSeconds(1.5f);
        fatherText.text = "";
        yield return new WaitForSeconds(.5f);

        fatherText.text = "...";
        yield return new WaitForSeconds(5);
        fatherText.text = "";
        yield return new WaitForSeconds(.5f);

        motherText.text = "What is it?";
        yield return new WaitForSeconds(1.2f);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        motherText.text = "John, what is it?";
        yield return new WaitForSeconds(1.2f);
        motherText.text = "";
        yield return new WaitForSeconds(.5f);

        fatherText.text = "...H-He's gone.";
        yield return new WaitForSeconds(2);
        fatherText.text = "";
        yield return new WaitForSeconds(.5f);

        //Monster Text Line
        monsterText.text = "Let's go back home. My darling child.";
        yield return new WaitForSeconds(2);

        //Monster Text Line
        monsterText.text = "Now we can finally be together.";
        yield return new WaitForSeconds(1.5f);

        //Monster Text Line
        monsterText.text = "Forever.";
        yield return new WaitForSeconds(3);
        monsterText.text = "";
        yield return new WaitForSeconds(6f);

        Application.Quit();
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
        monsterText.text = "Why would you leave me?";
        yield return new WaitForSeconds(1.5f);

        //Monster Text Line
        monsterText.text = "I thought you liked me.";
        yield return new WaitForSeconds(1.5f);

        //Monster Text Line
        monsterText.text = "I guess just didn't want to be alone...";
        yield return new WaitForSeconds(3);

        //Monster Text Line
        monsterText.text = "Fine.";
        yield return new WaitForSeconds(1.2f);

        //Monster Text Line
        monsterText.text = "Just-";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "Just go.";
        yield return new WaitForSeconds(1.2f);

        //Monster Text Line
        monsterText.text = "I will just stay here.";
        yield return new WaitForSeconds(2);

        //Monster Text Line
        monsterText.text = "Alone.";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "For eternity.";
        yield return new WaitForSeconds(1);

        //Monster Text Line
        monsterText.text = "Farewell my child.";
        yield return new WaitForSeconds(2);

        monsterText.text = "";
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}