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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(loadNextScene());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        blackScreen.SetActive(true);
        player.SetActive(false);
        loadSound.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
