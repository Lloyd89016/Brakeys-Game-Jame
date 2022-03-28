using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameMusic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Level007" && SceneManager.GetActiveScene().name != "Level008")
        {
            Destroy(gameObject);
        }
    }
}
