using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attach these (Necessary)")]
    public Image healthImageBar; // the image bar in the canvas i mean the child of the transform.
    Player player;
    public GameObject playerObject;
    public Animator enemyAnimator;
    public GameObject EnemyObject;
    public MonoBehaviour enemyMovementScript;
    private Rigidbody2D rb2D;

    public float health = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthImageBar.fillAmount = health;

        if (health <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            enemyAnimator.SetBool("hasDied", true);
            enemyMovementScript.enabled = false;
            rb2D.velocity = new Vector2(0.0f, 0.0f);
            StartCoroutine(die());
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(1);
        Destroy(EnemyObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FlashLight")
        {
            health -= player.attackDamage;
        }
    }
}
