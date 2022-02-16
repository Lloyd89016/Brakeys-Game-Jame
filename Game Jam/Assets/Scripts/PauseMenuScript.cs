using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    private GameObject pauseMenu;

    public bool isPaused;

    public void Start()
    {
        pauseMenu = GameObject.Find("PauseMenuCanvas");
    }

    public void Update()
    {
        TurnOnAndOffPauseMenu();
    }

    //controls the pause menu
    public void TurnOnAndOffPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            //Pauses or unpauses the game
            isPaused = !isPaused;
        }

        if (isPaused == true)
        {
            pause();
        }
        else
        {
            unPause();
        }
    }

    public void pause()
    {
        //sets the pause menu gameobject to active
        pauseMenu.SetActive(true);

        //Pauses the game
        Time.timeScale = 0f;
    }

    public void unPause()
    {
        //Pauses the game
        pauseMenu.SetActive(false);

        //sets the pause menu gameobject to active
        Time.timeScale = 1.0f;
    }

    //Conrols Buttons

    public void resumeButton()
    {
        isPaused = false;
    }

    public void quitToMenuButton()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
