using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //W AT THE MOMENT YOU CAN KILL ENEMYS THOUGH OBJECTS PLS FIX THIS IDK HOW MAYBE LINE CASTS THATS WHAT I TRYED BUT IT DIDNT WORK.

    [Header("Attach these (Necessary)")]
    public Image healthImageBar; // the image bar in the canvas i mean the child of the transform.
    Player player;
    public GameObject playerObject;

    public GameObject EnemyObject;

    public float health = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthImageBar.fillAmount = health;

        if (health <= 0)
        {
            Destroy(EnemyObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject == player)
        {
            Destroy(player);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FlashLight")
        {
            health -= player.attackDamage;
        }
    }
}
