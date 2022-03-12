using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDontDestroyOnLoadObjectsScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        //Loads the pause menu if it isent allready is the scene
        if (!GameObject.Find("PauseMenuUI(Clone)"))
        {
            Instantiate(pauseMenu);
        }
    }
}
