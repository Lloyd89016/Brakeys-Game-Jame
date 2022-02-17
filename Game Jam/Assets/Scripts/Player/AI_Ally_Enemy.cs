using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Ally_Enemy : MonoBehaviour
{
    [Header("Necessary")]
    public GameObject player;
    public LayerMask ground;
    public LayerMask playerLayerMask; // you have to set a layermask on the player and set the layermask in inspector. Contact W if you get confused.

    [Header("Ally")]
    public bool Ally = false;

    [Header("Enemy")]
    public bool Enemy = false;

    [Header("Other Settings")]
    public float speed = 10f;
    public float jumpPower = 10f;
    public bool pathfinderOn = true;
    public float pathfinder_StopRadius = 5f; // radius to stop if the player is close. Contact W if you get confused.


    // Private variables

    int direction = 0;
    bool playerInRange;

    private void Start()
    {
        
    }

    private void Update()
    {

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

        if (Ally)
        {
            
        }
    }

}
