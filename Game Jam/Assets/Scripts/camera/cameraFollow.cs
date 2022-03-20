using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public bool noY;
    private float yPos;
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    void Start()
    {
        yPos = transform.position.y;
        //Sets the position of the camera to the correct place in the first frame
        transform.position = player.position + cameraOffset;
    }

    void FixedUpdate()
    {
        //Sets the target postion
        Vector3 targetPos = player.position + cameraOffset;

        if (noY == true)
        {
            targetPos.y = yPos;
        }

        //Commits a lerp
        Vector3 lerpPosition = Vector3.Lerp(transform.position, targetPos, cameraSpeed);

        //Sets the camera pos to the lerped postion
        transform.position = lerpPosition;
    }
}
