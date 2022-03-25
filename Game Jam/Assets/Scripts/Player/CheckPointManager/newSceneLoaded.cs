using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSceneLoaded : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("CheckPointManager").GetComponent<CheckPointManager>().newSceneLoaded = true;
    }
}
