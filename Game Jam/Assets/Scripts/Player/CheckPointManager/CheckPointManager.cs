using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour
{
    public GameObject player;

    public bool newSceneLoaded;

    public Vector3 currentCheckPoint;

    public string loadedScene;

    private void Awake()
    {
        player = GameObject.Find("Player");
        currentCheckPoint = player.transform.position;
        gameObject.name = "CheckPointManager";
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        player = GameObject.Find("Player");
        loadedScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if(newSceneLoaded == true)
        {
            player = GameObject.Find("Player");

            //Checks if its the first time the scenes been loaded
            if(SceneManager.GetActiveScene().name != loadedScene)
            {
                currentCheckPoint = player.transform.position;
                loadedScene = SceneManager.GetActiveScene().name;
            }

            newSceneLoaded = false;
        }

        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CheckPoint")
        {
            currentCheckPoint = transform.transform.position;
        }
    }
}
