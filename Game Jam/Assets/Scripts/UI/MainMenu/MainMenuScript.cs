using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject buttonsCanvas;
    public GameObject LoadScreen;

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
        LoadScreen.SetActive(true);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        //quits the applactaion
        Application.Quit();
    }
}
