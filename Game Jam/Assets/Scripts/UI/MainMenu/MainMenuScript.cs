using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        //destroys the pause menu when the main menu loads so it can be reloaded when the play button is pressed
        Destroy(GameObject.Find("PauseMenuUI(Clone)"));
    }

    public void playButton()
    {
        //Loads the pause menu when the play button is pressed
        if (!GameObject.Find("PauseMenuUI(Clone)"))
        {
            Instantiate(pauseMenu);
        }

        //loads the next scene in the build index when the play button is pressed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        //quits the applactaion
        Application.Quit();
    }
}
