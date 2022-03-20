using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelObjectScript : MonoBehaviour
{
    public GameObject blackScreen;
    private GameObject player;
    public AudioSource loadSound;

    private void Start()
    {
        player = GameObject.Find("Player");
        blackScreen.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(loadNextScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        blackScreen.SetActive(true);
        loadSound.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
