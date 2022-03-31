using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject buttonsCanvas;
    public Text text;
    public GameObject loadCanvas;
    public AudioSource clothSound;

    private void Start()
    {
        //destroys the pause menu when the main menu loads
        Destroy(GameObject.Find("PauseMenuUI(Clone)"));
    }

    public void playButton()
    {
        StartCoroutine(play());
    }

    IEnumerator play()
    {
        Destroy(buttonsCanvas);
        loadCanvas.SetActive(true);
        text.text = "They wander through the caves and corridors of the mind, fearing nothing but a ray of light shining upon their dark figure. Casting them away from this plane of existence.";
        yield return new WaitForSeconds(7);

        text.text = "Oh, look at the time!";
        yield return new WaitForSeconds(2);

        text.text = "It's time for you to go to bed! We can keep reading tomorrow night.";
        yield return new WaitForSeconds(4);

        text.text = "Goodnight son";
        yield return new WaitForSeconds(1);

        text.text = "";
        yield return new WaitForSeconds(1);
        clothSound.Play();
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        //quits the applactaion
        Application.Quit();
    }
}
