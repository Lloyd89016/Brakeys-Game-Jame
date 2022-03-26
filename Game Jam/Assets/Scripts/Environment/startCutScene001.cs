using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startCutScene001 : MonoBehaviour
{
    //The player
    public GameObject player;

    //the enemys that aprotch you
    public GameObject enemy001;
    public GameObject enemy002;

    //Canvas with the "wake up" text
    public Text wakeUpText;

    //floor below player
    public GameObject floor;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(cutScene());
        }
    }

    IEnumerator cutScene()
    {
        //Sets the enemys as active
        //enemy001.SetActive(true);
        //enemy002.SetActive(true);

        //Flashes the "Wake Up" Text
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "Hello there child!";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "You seem to be lost";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "And afraid.";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "And stuck in a hole.";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "Don't worry";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "I'll take you in";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "Let me bring you to my dewlling";
        yield return new WaitForSeconds(2f);

        wakeUpText.text = "";

        floor.SetActive(false);
    }
}
