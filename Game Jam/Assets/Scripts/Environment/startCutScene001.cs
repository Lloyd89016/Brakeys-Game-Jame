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
            StartCoroutine(cutScene());
        }
    }

    IEnumerator cutScene()
    {
        //Sets the enemys as active
        //enemy001.SetActive(true);
        //enemy002.SetActive(true);

        //Flashes the "Wake Up" Text
        yield return new WaitForSeconds(.2f);

        wakeUpText.text = "Wake Up";
        yield return new WaitForSeconds(.8f);

        wakeUpText.text = "Son";
        yield return new WaitForSeconds(.6f);

        wakeUpText.text = "Your having a n-";
        yield return new WaitForSeconds(1.1f);

        wakeUpText.text = "";

        floor.SetActive(false);
    }
}
