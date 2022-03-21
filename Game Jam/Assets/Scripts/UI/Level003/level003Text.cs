using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level003Text : MonoBehaviour
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
        enemyText.text = "Congradulations.";

        yield return new WaitForSeconds(3);
        enemyText.text = "You did it.";

        yield return new WaitForSeconds(3);
        enemyText.text = "You woke up";

        yield return new WaitForSeconds(3);
        enemyText.text = "You should be proud.";

        yield return new WaitForSeconds(3);
        enemyText.text = "Not everyone manages.";

        yield return new WaitForSeconds(3);
        enemyText.text = "Well. Go about your life. I wont bother you.";

        yield return new WaitForSeconds(3);
        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
    }
}
