using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackAndFourth : MonoBehaviour
{

    [Header("BACK AND FOURTH")]
    public float xPos001;
    public float xPos002;

    public Vector3 target;

    public float moveSpeed = 10;

    [Header("FOLLOW PLAYER")]

    public GameObject player;
    public float followMoveSpeed = 10;
    public Vector3 followTarget;


    void Start()
    {
        player = GameObject.Find("Player");

        target = new Vector3(xPos001, transform.position.y, 0);
    }

    public bool isFollowActive;

    void Update()
    {
        if (isFollowActive == true)
        {
            Follow();
        }
        else
        {
            MoveBackAndFourth();
        }
    }


    void MoveBackAndFourth()
    {
        //Finds the higher of the 2 goals and goes to that one first
        float higherGoal = Math.Max(xPos001, xPos002);

        //turns the enemy sprite
        if (target.x == higherGoal)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //Changes the target location when it gets to the privius target location
        if (transform.position == target)
        {
            if (transform.position.x == xPos001)
            {
                target = new Vector3(xPos002, transform.position.y, 0);
            }
            else if (transform.position.x == xPos002)
            {
                target = new Vector3(xPos001, transform.position.y, 0);
            }
        }

        //Sets the y to that for the floor
        target = new Vector3(target.x, transform.position.y, 0);

        //moves the enemy
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    void Follow()
    {
        //Sets the target
        followTarget = player.transform.position;

        //Sets the y to that of the floor
        followTarget = new Vector3(followTarget.x, transform.position.y, 0);

        //turns the enemy sprite
        if (followTarget.x > transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //moves the enemy
        transform.position = Vector3.MoveTowards(transform.position, followTarget, followMoveSpeed * Time.deltaTime);
    }
}
