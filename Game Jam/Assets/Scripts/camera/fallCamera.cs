using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;
    private Vector3 target;

    void Start()
    {
        player = GameObject.Find("Player");

        target = player.transform.position + cameraOffset;

        transform.position = target;
    }

    void Update()
    {
        target = player.transform.position + cameraOffset;

        transform.position = target;   
    }
}
