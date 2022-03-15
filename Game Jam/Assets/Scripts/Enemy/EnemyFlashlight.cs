using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashlight : MonoBehaviour
{
    public GameObject Enemy;

    private void Start()
    {
        Enemy.GetComponent<EnemyBackAndFourth>().isFollowActive = false;
    }

    //Makes the light face the same way as the enemy.
    private void Update()
    {
        transform.position = Enemy.transform.position;

        if(Enemy.transform.localScale.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if(Enemy.transform.localScale.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Enemy.GetComponent<EnemyBackAndFourth>().isFollowActive = true;
            //StartCoroutine(changeIsFollowActive());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(changeIsFollowActive());
        }
    }

    IEnumerator changeIsFollowActive()
    {   
        yield return new WaitForSeconds(2);
        Enemy.GetComponent<EnemyBackAndFourth>().isFollowActive = false;
    }
}
