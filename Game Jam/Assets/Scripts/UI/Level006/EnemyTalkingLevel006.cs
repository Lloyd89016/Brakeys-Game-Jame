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
        text.text = "You shoulden't be walking around";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Well good luck getting out of here";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Trust me you'll need it";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(10);

        //New line
        text.text = "Your doing a bad job";
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
        text.text = "Becuse I can garentee that you will never be able to get to the exit.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "If there even is an exit";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "In this existance there is nothing that is not seen";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "so at the moment your just kind of trying to get to somthing that dosent exist";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Rather sad if you ask me";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Whats even worse is that your not even doing a good job of it";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

    }
}
