using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyTalkingLevel006 : MonoBehaviour
{
    public Text text;

    private void Awake()
    {
        gameObject.name = "TalkingEnemyManager";
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        text = GameObject.Find("EnemyText").GetComponent<Text>();
        StartCoroutine(enemyTalk());
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "Level006")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator enemyTalk()
    {
        //New line
        text.text = "What are you doing here?";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "You went to bed";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "You shouldn't be meanding around";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Well, best wishes of getting out of here";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Or. You could just go back to sleeping";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(10);

        //New line
        text.text = "You're doing a bad job";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Just so we're all clear on that.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(10);

        //New line
        text.text = "Have you given up yet?";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Because I can garentee that you will never be able to get to the exit.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "If there even is one";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "In this existance there is nothing that is not seen";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "So at the moment you're trying to get to something that doesn't exist";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Rather sad if you ask me";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "What's even worse is that your'e not even doing a good job of it";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

    }
}
