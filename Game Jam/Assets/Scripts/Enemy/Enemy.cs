using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attach these (Necessary)")]
    public GameObject flashlight;
    public Image healthImageBar; // the image bar in the canvas i mean the child of the transform.

    Player player;
    public float health = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImageBar.fillAmount = health;

        if (health <= 0)
        {
            Destroy(gameObject);
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
        if (collision.gameObject == flashlight)
        {
            health -= player.attackDamage;
        }
    }
}
