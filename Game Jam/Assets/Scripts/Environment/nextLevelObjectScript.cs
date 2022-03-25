using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelObjectScript : MonoBehaviour
{
    public GameObject blackScreen;
    private GameObject player;
    public AudioSource loadSound;

    public float waitBeforeLoad = 2;

    public Canvas canvas;

    public bool hasToPressKey;

    private void Start()
    {
        player = GameObject.Find("Player");
        blackScreen.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Turns on the hint text
        if (collision.gameObject.name == "Player" && hasToPressKey == true)
        {
            canvas.enabled = true;
        }

        if (hasToPressKey == true)
        {
            if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
            {
                canvas.enabled = false;
                StartCoroutine(loadNextScene());
            }
        }
        else
        {
            if (collision.gameObject.name == "Player")
            {
                StartCoroutine(loadNextScene());
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turns off the hint text
        if (collision.gameObject.name == "Player" && hasToPressKey == true)
        {
            canvas.enabled = false;
        }
    }

    IEnumerator loadNextScene()
    {
        blackScreen.SetActive(true);
        player.SetActive(false);
        loadSound.Play();
        yield return new WaitForSeconds(waitBeforeLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
