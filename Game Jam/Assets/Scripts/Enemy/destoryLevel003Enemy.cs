using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destoryLevel003Enemy : MonoBehaviour
{
    public GameObject enemyObject;

    public Text enemyText;

    public GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(enemyObject);
            StartCoroutine(enemyTalk());
        }
    }

    IEnumerator enemyTalk()
    {
        yield return new WaitForSeconds(.7f);

        //Freezes the player
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<PlayerMovmentScript>().enabled = false;
        enemyText.text = "It's crazy what the human mind is cabable of.";
        yield return new WaitForSeconds(2.2f);

        enemyText.text = "Seeing figures where there is really nothing.";
        yield return new WaitForSeconds(2.2f);

        enemyText.text = "Fascinating isn't it.";
        yield return new WaitForSeconds(1.7f);

        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


        yield return new WaitForSeconds(15);

        enemyText.text = "Are you just going to sit inside all day?";
        yield return new WaitForSeconds(2.5f);

        enemyText.text = "";
    }

}
