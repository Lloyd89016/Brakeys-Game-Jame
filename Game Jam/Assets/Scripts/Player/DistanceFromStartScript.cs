using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromStartScript : MonoBehaviour
{
    private float startXPos;

    private float distanceFromStart;

    public int score;

    void Start()
    {
        startXPos = transform.position.x;
    }

    void Update()
    {

        distanceFromStart = transform.position.x - startXPos;

        if (distanceFromStart > 0)
        {
            score = Mathf.RoundToInt(distanceFromStart);
        }
    }


}
