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
        
        yield return new WaitForSeconds(1.2f);

        enemyText.text = "Hello again.";
        yield return new WaitForSeconds(1.5f);

        enemyText.text = "So. This is my home.";
        yield return new WaitForSeconds(2);
        
        enemyText.text = "Feel free to make yourself at home.";
        yield return new WaitForSeconds(2.3f);

        enemyText.text = "Oh, I have an idea! You could go out and play!";
        yield return new WaitForSeconds(3);

        enemyText.text = "The fresh air will be good for you.";
        yield return new WaitForSeconds(2.2f);

        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
    }
}
