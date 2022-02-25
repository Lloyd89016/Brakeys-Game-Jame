using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackAndFourth : MonoBehaviour
{


    void Start()
    {
        target = new Vector3(xPos001, transform.position.y, 0);
    }

    public bool isFollowActive;

    void Update()
    {
        if(isFollowActive == true)
        {
            Follow();
        }
        else
        {
            MoveBackAndFourth();
        }
    }

    [Header("BACK AND FOURTH")]
    public float xPos001;
    public float xPos002;

    public Vector3 target;

    public float moveSpeed = 10;

    void MoveBackAndFourth()
    {

        //turns the enemy sprite
        float higherGoal = Math.Max(xPos001, xPos002);
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




    [Header("FOLLOW PLAYER")]
    public GameObject player;
    public LayerMask ground;
    public LayerMask playerLayerMask; // you have to set a layermask on the player and set the layermask in inspector. Contact W if you get confused.
    public LayerMask jumpingObjectsLayerMask; // set a layermask on all the objects that the ally/enemy ai should jump.


    [Header("Ally")]
    public bool Ally = false;

    [Header("Enemy")]
    public bool Enemy = false;

    [Header("Other Settings")]
    public float speed = 10f;
    public bool jump = true;
    public float jumpPower = 10f;
    public bool pathfinderOn = true;
    public float pathfinder_StopRadius = 5f; // radius to stop if the player is close. Contact W if you get confused.
    public float wallsJumpDistance = 2f;


    // Private variables

    bool playerInRange;
    bool shouldJump = false;

    void Follow()
    {
        float prevPos = transform.position.x;
        playerInRange = Physics2D.OverlapCircle(transform.position, pathfinder_StopRadius, playerLayerMask);
        if (playerInRange)
        {
            pathfinderOn = false;
        }
        else
        {
            pathfinderOn = true;
        }

        if (pathfinderOn)
        {
            Vector2 pos = transform.position;
            if (player.GetComponent<Transform>().position.x > GetComponent<Transform>().position.x)
            {
                pos.x += speed * Time.deltaTime;
            }
            else if (player.GetComponent<Transform>().position.x < GetComponent<Transform>().position.x)
            {
                pos.x += -speed * Time.deltaTime;
            }
            transform.position = pos;
        }

        if (jump)
        {
            if (prevPos < transform.position.x)
            {
                shouldJump = Physics2D.Raycast(transform.position, Vector2.right, wallsJumpDistance, jumpingObjectsLayerMask);
            }
            else if (prevPos > transform.position.x)
            {
                shouldJump = Physics2D.Raycast(transform.position, Vector2.left, wallsJumpDistance, jumpingObjectsLayerMask);
            }
        }

        if (shouldJump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpPower);
            shouldJump = false;
        }
    }
}
