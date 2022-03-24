using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level005Text : MonoBehaviour
{

    public Text enemyText;

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(enemyTalk());
    }

    IEnumerator enemyTalk()
    {
        //Freezes the player
        player.GetComponent<PlayerMovmentScript>().enabled = false;

        yield return new WaitForSeconds(3);
        enemyText.text = "Back from playing already?.";

        yield return new WaitForSeconds(3);
        enemyText.text = "How was it?";

        yield return new WaitForSeconds(3);
        enemyText.text = "Fun im sure";

        yield return new WaitForSeconds(3);
        enemyText.text = "Now I think its time for bed.";

        yield return new WaitForSeconds(3);
        enemyText.text = "Don't you?";

        yield return new WaitForSeconds(3);
        enemyText.text = "Goodnight child.";

        yield return new WaitForSeconds(3);
        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
    }
}