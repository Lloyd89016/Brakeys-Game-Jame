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
        enemyText.text = "Its crazy what the human mid is cabable of.";
        yield return new WaitForSeconds(3);

        enemyText.text = "Seeing figures where there is really nothing";
        yield return new WaitForSeconds(3);

        enemyText.text = "Fasinating isen't it";
        yield return new WaitForSeconds(2);

        enemyText.text = "";
        player.GetComponent<PlayerMovmentScript>().enabled = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


        yield return new WaitForSeconds(15);
        enemyText.text = "Are you just goint to sit inside all day?";

        yield return new WaitForSeconds(3);
        enemyText.text = "How about getting some fresh air?";

        yield return new WaitForSeconds(3);
        enemyText.text = "";
    }

}
