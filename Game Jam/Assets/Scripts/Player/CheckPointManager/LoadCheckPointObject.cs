using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckPointObject : MonoBehaviour
{
    public GameObject CheckPointManager;

    void Awake()
    {
        if(GameObject.Find("CheckPointManager") == null)
        {
            Instantiate(CheckPointManager);
        }
    }
}
