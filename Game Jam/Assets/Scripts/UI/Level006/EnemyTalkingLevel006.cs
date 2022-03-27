using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyTalkingLevel006 : MonoBehaviour
{
    public Text text;
    public Canvas canvas;

    private void Awake()
    {
        gameObject.name = "TalkingEnemyManager";
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        text = GameObject.Find("EnemyText").GetComponent<Text>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
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
        yield return new WaitForSeconds(.1f);
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
        text.text = "You shouldn't be walking around";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Please child. Just come back home";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "You won't get to whereever your going";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Think of the life we could have togther";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Nither of us would ever be alone again";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Please child. Do not go up there";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "We will play games every night before i put you to sleep with a story";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Just like she did.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "You don't really want whats at the top.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "That world...";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Its horrible";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Just come back home.";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

        //New line
        text.text = "Please";
        yield return new WaitForSeconds(3);
        text.text = "";
        yield return new WaitForSeconds(3);

    }
}
