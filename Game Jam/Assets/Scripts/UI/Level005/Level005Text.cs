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

        yield return new WaitForSeconds(2);

        enemyText.text = "Back from playing already?";
        yield return new WaitForSeconds(1.5f);

        enemyText.text = "How was it?";
        yield return new WaitForSeconds(1.2f);

        enemyText.text = "Fun I'm sure.";
        yield return new WaitForSeconds(1.2f);

        enemyText.text = "Now I think it's time for bed.";
        yield return new WaitForSeconds(2);

        enemyText.text = "Don't you?";
        yield return new WaitForSeconds(1.5f);

        enemyText.text = "Goodnight child.";
        yield return new WaitForSeconds(1.5f);

        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
    }
}
