using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadEenemyTalkingLevel6 : MonoBehaviour
{
    public GameObject talkingEnemyManager;

    void Start()
    {
        if(GameObject.Find("TalkingEnemyManager") == null)
        {
            Instantiate(talkingEnemyManager);
        }
    }
}
